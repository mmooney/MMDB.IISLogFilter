using MMDB.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMDB.IisLogFilter.Exe
{
	public partial class dlgMain : Form
	{
		protected BindingList<FileListItem> _fileList = new BindingList<FileListItem>();
		public dlgMain()
		{
			InitializeComponent();
			_lstFiles.DataSource = _fileList;
			_lstFiles.DisplayMember = "DisplayValue";
		}


		private void _btnAddFile_Click(object sender, EventArgs e)
		{
			using (var dlg = new OpenFileDialog() { AddExtension = true, CheckFileExists = true, CheckPathExists = true, Multiselect = true })
			{
				dlg.Filter = "Log Files (*.log)|*.log|All Files (*.*)|*.*";
				var result = dlg.ShowDialog();
				switch (result)
				{
					case System.Windows.Forms.DialogResult.OK:
					case System.Windows.Forms.DialogResult.Yes:
						foreach (var fileName in dlg.FileNames)
						{
							if (!_fileList.Any(i => fileName.Equals(i.Path, StringComparison.CurrentCultureIgnoreCase)))
							{
								_fileList.Add(new FileListItem { Path = fileName, IsDirectory = false });
							}
						}
						break;
				}
			}
		}

		private void _btnAddDirectory_Click(object sender, EventArgs e)
		{
			using (var dlg = new FolderBrowserDialog() { ShowNewFolderButton = false })
			{
				var result = dlg.ShowDialog();
				switch (result)
				{
					case System.Windows.Forms.DialogResult.Yes:
					case System.Windows.Forms.DialogResult.OK:
						var recurseResult = MessageBox.Show("Do you want to include child directories?", null, MessageBoxButtons.YesNoCancel);
						switch (recurseResult)
						{
							case System.Windows.Forms.DialogResult.Yes:
							case System.Windows.Forms.DialogResult.OK:
								_fileList.Add(new FileListItem { IsDirectory = true, Path = dlg.SelectedPath, RecurseDirectories = true });
								break;
							case System.Windows.Forms.DialogResult.No:
								_fileList.Add(new FileListItem { IsDirectory = true, Path = dlg.SelectedPath, RecurseDirectories = false });
								break;
							case System.Windows.Forms.DialogResult.Cancel:
								return;
						}
						break;
				}
			}
		}

		private void _lstFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			_btnRemoveFiles.Enabled = (_lstFiles.SelectedItems.Count > 0);
		}

		private void _btnRemoveFiles_Click(object sender, EventArgs e)
		{
			var itemsToDelete = new List<FileListItem>();
			foreach (var item in _lstFiles.SelectedItems)
			{
				itemsToDelete.Add((FileListItem)item);
			}
			foreach (var item in itemsToDelete)
			{
				_fileList.Remove(item);
			}
		}

		private void _btnGo_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(_txtOutputFile.Text))
			{
				MessageBox.Show("Please enter a output file");
				return;
			}

			var outputList = new List<LogItem>();
			foreach (var item in _fileList)
			{
				if (item.IsDirectory)
				{
					var tempList = ProcessDirectory(item.Path, item.RecurseDirectories);
					outputList.AddRange(tempList);
				}
				else
				{
					var tempList = ProcessFile(item.Path);
					outputList.AddRange(tempList);
				}
			}
			if (_rdoCombineFiles.Checked)
			{
				var sortedList = outputList.OrderBy(i => i.Date).ToList();
				using (var writer = new StreamWriter(_txtOutputFile.Text, _chkAppendOutputFile.Checked))
				{
					foreach (var item in sortedList)
					{
						writer.WriteLine(item.RawLogMessage);
					}
				}
				MessageBox.Show($"Done writing {sortedList.Count} records to {_txtOutputFile.Text}");
			}
			else if (_rdoCountIPAddresses.Checked)
			{
				var ipAddressList = outputList
						.Select(i => new Tuple<string, int>(i.SourceIP.Split(',')[0],
											outputList.Where(x => x.SourceIP == i.SourceIP).Count()))
						.Distinct().OrderByDescending(i => i.Item2).ToList();
				using (var writer = new StreamWriter(_txtOutputFile.Text, _chkAppendOutputFile.Checked))
				{
					writer.WriteLine($"IPAddress,Count");
					foreach (var ipAddress in ipAddressList)
					{
						writer.WriteLine($"{ipAddress.Item1},{ipAddress.Item2}");
					}
				}
				//var sortedList = ipAddressCountList.OrderByDescending(i => i.Value).ToList();
				MessageBox.Show($"Done writing {ipAddressList.Count} IP records to {_txtOutputFile.Text}");
			}
			else if (_rdoCountUserAgents.Checked)
			{
                var userAgents = outputList
                        .Select(i => new Tuple<string, int>(i.UserAgent,
                                            outputList.Where(x => x.UserAgent == i.UserAgent).Count()))
                        .Distinct().OrderByDescending(i => i.Item2).ToList();
                using (var writer = new StreamWriter(_txtOutputFile.Text, _chkAppendOutputFile.Checked))
                {
                    writer.WriteLine($"UserAgent,Count");
                    foreach (var ipAddress in userAgents)
                    {
                        writer.WriteLine($"{ipAddress.Item1},{ipAddress.Item2}");
                    }
                }
                //var sortedList = ipAddressCountList.OrderByDescending(i => i.Value).ToList();
                MessageBox.Show($"Done writing {userAgents.Count} IP records to {_txtOutputFile.Text}");
            }
            else
			{
				MessageBox.Show("Nothing to do");
			}
		}

		private List<LogItem> ProcessFile(string path)
		{
			var returnList = new List<LogItem>();

			int? dateFieldIndex = null;
			int? timeFieldIndex = null;
			int? sourceIPFieldIndex = null;
			int? uriStemFieldIndex = null;
			int? queryStringFieldIndex = null;
			int? userNameFieldIndex = null;
			int? userAgentFieldIndex = null;
			int? httpStatusFieldIndex = null;
			int? xForwardedForIndex = null;
			int? originalIPIndex = null;

			using (var reader = new StreamReader(path))
			{
				var firstLine = reader.ReadLine();
				if (!firstLine.StartsWith("#Software:"))
				{
					return new List<LogItem>();
				}
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					if (line.StartsWith("#Fields:"))
					{
						dateFieldIndex = null;
						timeFieldIndex = null;
						sourceIPFieldIndex = null;
						uriStemFieldIndex = null;
						queryStringFieldIndex = null;
						userNameFieldIndex = null;
						userAgentFieldIndex = null;
						httpStatusFieldIndex = null;
						originalIPIndex = null;
						var parts = line.Split(' ');
						for (var i = 0; i < parts.Length; i++)
						{
							if (parts[i] == "date")
							{
								dateFieldIndex = i - 1;
							}
							if (parts[i] == "time")
							{
								timeFieldIndex = i - 1;
							}
							if (parts[i] == "c-ip")
							{
								sourceIPFieldIndex = i - 1;
							}
							if (parts[i] == "cs-uri-stem")
							{
								uriStemFieldIndex = i - 1;
							}
							if (parts[i] == "cs-uri-query")
							{
								queryStringFieldIndex = i - 1;
							}
							if (parts[i] == "cs-username")
							{
								userNameFieldIndex = i - 1;
							}
							if (parts[i] == "cs(User-Agent)")
							{
								userAgentFieldIndex = i - 1;
							}
							if (parts[i] == "sc-status")
							{
								httpStatusFieldIndex = i - 1;
							}
							if (parts[i] == "X-FORWARDED-FOR")
							{
								xForwardedForIndex = i - 1;
							}
							if (parts[i] == "OriginalIP")
							{
								originalIPIndex = i - 1;
							}

						}
					}
					else if (!line.StartsWith("#"))
					{
						var parts = line.Split(' ');
						var item = new LogItem
						{
							RawLogMessage = line,
							Date = TryBuildDateTime(parts, dateFieldIndex, timeFieldIndex),
							HttpStatus = TryGetValue(parts, httpStatusFieldIndex),
							QueryString = TryGetValue(parts, queryStringFieldIndex),
							SourceIP = StringHelper.IsNullOrEmpty(TryGetValue(parts, originalIPIndex), TryGetValue(parts, xForwardedForIndex), TryGetValue(parts, sourceIPFieldIndex)),
							UriStem = TryGetValue(parts, uriStemFieldIndex),
							User = TryGetValue(parts, userNameFieldIndex),
							UserAgent = TryGetValue(parts, userAgentFieldIndex)
						};
						if (ClearsFilters(item))
						{
							returnList.Add(item);
						}
					}
				}
			}
			return returnList;
		}

		private bool ClearsFilters(LogItem item)
		{
			if (!ClearFilterItem(item.HttpStatus, _txtHttpStatus, _chkExcludeHttpStatus))
			{
				return false;
			}
			if (!ClearFilterItem(item.SourceIP, _txtSourceIP, _chkExcludeSourceIP))
			{
				return false;
			}
			if (!ClearFilterItem(item.User, _txtUser, _chkExcludeUser))
			{
				return false;
			}
			if (!ClearFilterItem(item.UserAgent, _txtUserAgent, _chkExcludeUserAgent))
			{
				return false;
			}
			if (!ClearFilterItem(item.UriStem, _txtUrl, _chkExcludeUrl))
			{
				return false;
			}
			if (!ClearFilterItem(item.QueryString, _txtQueryString, _chkExcludeQueryString))
			{
				return false;
			}
			return true;
		}

		private bool ClearFilterItem(string value, TextBox filterTextBox, CheckBox excludeCheckBox)
		{
			if (string.IsNullOrEmpty(filterTextBox.Text))
			{
				return true;
			}
			if (string.IsNullOrEmpty(value))
			{
				return !excludeCheckBox.Checked;
			}
			if (value.ToLower().Contains(filterTextBox.Text.ToLower()))
			{
				return !excludeCheckBox.Checked;
			}
			else
			{
				return excludeCheckBox.Checked;
			}
		}

		private string TryGetValue(string[] parts, int? fieldIndex)
		{
			if (parts == null || !fieldIndex.HasValue || fieldIndex >= parts.Length)
			{
				return null;
			}
			return parts[fieldIndex.Value];
		}

		private DateTime? TryBuildDateTime(string[] parts, int? dateFieldIndex, int? timeFieldIndex)
		{
			var dateValue = TryGetValue(parts, dateFieldIndex);
			var timeValue = TryGetValue(parts, timeFieldIndex);
			if (string.IsNullOrEmpty(dateValue))
			{
				return null;
			}
			if (string.IsNullOrEmpty(timeValue))
			{
				return DateTime.SpecifyKind(DateTime.ParseExact(dateValue, "yyyy-MM-dd", CultureInfo.CurrentCulture), DateTimeKind.Utc);
			}
			else
			{
				return DateTime.SpecifyKind(DateTime.ParseExact(dateValue + " " + timeValue, "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture), DateTimeKind.Utc);
			}
		}

		private List<LogItem> ProcessDirectory(string path, bool recurse)
		{
			var returnList = new List<LogItem>();
			var directoryInfo = new DirectoryInfo(path);
			foreach (var file in directoryInfo.GetFiles())
			{
				var fileTempList = ProcessFile(file.FullName);
				returnList.AddRange(fileTempList);
			}
			if (recurse)
			{
				foreach (var subDirectory in directoryInfo.GetDirectories())
				{
					var directoryTempList = ProcessDirectory(subDirectory.FullName, recurse);
					returnList.AddRange(directoryTempList);
				}
			}
			return returnList;
		}

    }
}
