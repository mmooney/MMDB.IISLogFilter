namespace MMDB.IisLogFilter.Exe
{
    partial class dlgMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._lstFiles = new System.Windows.Forms.ListBox();
            this._btnAddFile = new System.Windows.Forms.Button();
            this._btnAddDirectory = new System.Windows.Forms.Button();
            this._btnRemoveFiles = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this._txtSourceIP = new System.Windows.Forms.TextBox();
            this._txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._txtUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._chkExcludeSourceIP = new System.Windows.Forms.CheckBox();
            this._chkExcludeUser = new System.Windows.Forms.CheckBox();
            this._chkExcludeUrl = new System.Windows.Forms.CheckBox();
            this._chkExcludeHttpStatus = new System.Windows.Forms.CheckBox();
            this._txtHttpStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._chkExcludeUserAgent = new System.Windows.Forms.CheckBox();
            this._txtUserAgent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this._txtOutputFile = new System.Windows.Forms.TextBox();
            this._chkAppendOutputFile = new System.Windows.Forms.CheckBox();
            this._btnGo = new System.Windows.Forms.Button();
            this._chkExcludeQueryString = new System.Windows.Forms.CheckBox();
            this._txtQueryString = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lstFiles
            // 
            this._lstFiles.FormattingEnabled = true;
            this._lstFiles.Location = new System.Drawing.Point(23, 19);
            this._lstFiles.Name = "_lstFiles";
            this._lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._lstFiles.Size = new System.Drawing.Size(424, 134);
            this._lstFiles.TabIndex = 0;
            this._lstFiles.SelectedIndexChanged += new System.EventHandler(this._lstFiles_SelectedIndexChanged);
            // 
            // _btnAddFile
            // 
            this._btnAddFile.Location = new System.Drawing.Point(21, 168);
            this._btnAddFile.Name = "_btnAddFile";
            this._btnAddFile.Size = new System.Drawing.Size(95, 23);
            this._btnAddFile.TabIndex = 1;
            this._btnAddFile.Text = "Add File";
            this._btnAddFile.UseVisualStyleBackColor = true;
            this._btnAddFile.Click += new System.EventHandler(this._btnAddFile_Click);
            // 
            // _btnAddDirectory
            // 
            this._btnAddDirectory.Location = new System.Drawing.Point(122, 168);
            this._btnAddDirectory.Name = "_btnAddDirectory";
            this._btnAddDirectory.Size = new System.Drawing.Size(95, 23);
            this._btnAddDirectory.TabIndex = 3;
            this._btnAddDirectory.Text = "Add Directory";
            this._btnAddDirectory.UseVisualStyleBackColor = true;
            this._btnAddDirectory.Click += new System.EventHandler(this._btnAddDirectory_Click);
            // 
            // _btnRemoveFiles
            // 
            this._btnRemoveFiles.Enabled = false;
            this._btnRemoveFiles.Location = new System.Drawing.Point(223, 168);
            this._btnRemoveFiles.Name = "_btnRemoveFiles";
            this._btnRemoveFiles.Size = new System.Drawing.Size(95, 23);
            this._btnRemoveFiles.TabIndex = 4;
            this._btnRemoveFiles.Text = "Remove Item";
            this._btnRemoveFiles.UseVisualStyleBackColor = true;
            this._btnRemoveFiles.Click += new System.EventHandler(this._btnRemoveFiles_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btnRemoveFiles);
            this.groupBox1.Controls.Add(this._lstFiles);
            this.groupBox1.Controls.Add(this._btnAddDirectory);
            this.groupBox1.Controls.Add(this._btnAddFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 207);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files To Process";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._chkExcludeQueryString);
            this.groupBox2.Controls.Add(this._txtQueryString);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this._chkExcludeUserAgent);
            this.groupBox2.Controls.Add(this._txtUserAgent);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this._chkExcludeHttpStatus);
            this.groupBox2.Controls.Add(this._txtHttpStatus);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this._chkExcludeUrl);
            this.groupBox2.Controls.Add(this._chkExcludeUser);
            this.groupBox2.Controls.Add(this._chkExcludeSourceIP);
            this.groupBox2.Controls.Add(this._txtUrl);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this._txtUser);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this._txtSourceIP);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 197);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source IP:";
            // 
            // _txtSourceIP
            // 
            this._txtSourceIP.Location = new System.Drawing.Point(95, 29);
            this._txtSourceIP.Name = "_txtSourceIP";
            this._txtSourceIP.Size = new System.Drawing.Size(100, 20);
            this._txtSourceIP.TabIndex = 1;
            // 
            // _txtUser
            // 
            this._txtUser.Location = new System.Drawing.Point(95, 55);
            this._txtUser.Name = "_txtUser";
            this._txtUser.Size = new System.Drawing.Size(100, 20);
            this._txtUser.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "User";
            // 
            // _txtUrl
            // 
            this._txtUrl.Location = new System.Drawing.Point(95, 81);
            this._txtUrl.Name = "_txtUrl";
            this._txtUrl.Size = new System.Drawing.Size(100, 20);
            this._txtUrl.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "URL:";
            // 
            // _chkExcludeSourceIP
            // 
            this._chkExcludeSourceIP.AutoSize = true;
            this._chkExcludeSourceIP.Location = new System.Drawing.Point(201, 29);
            this._chkExcludeSourceIP.Name = "_chkExcludeSourceIP";
            this._chkExcludeSourceIP.Size = new System.Drawing.Size(64, 17);
            this._chkExcludeSourceIP.TabIndex = 10;
            this._chkExcludeSourceIP.Text = "Exclude";
            this._chkExcludeSourceIP.UseVisualStyleBackColor = true;
            // 
            // _chkExcludeUser
            // 
            this._chkExcludeUser.AutoSize = true;
            this._chkExcludeUser.Location = new System.Drawing.Point(201, 55);
            this._chkExcludeUser.Name = "_chkExcludeUser";
            this._chkExcludeUser.Size = new System.Drawing.Size(64, 17);
            this._chkExcludeUser.TabIndex = 11;
            this._chkExcludeUser.Text = "Exclude";
            this._chkExcludeUser.UseVisualStyleBackColor = true;
            // 
            // _chkExcludeUrl
            // 
            this._chkExcludeUrl.AutoSize = true;
            this._chkExcludeUrl.Location = new System.Drawing.Point(201, 81);
            this._chkExcludeUrl.Name = "_chkExcludeUrl";
            this._chkExcludeUrl.Size = new System.Drawing.Size(64, 17);
            this._chkExcludeUrl.TabIndex = 12;
            this._chkExcludeUrl.Text = "Exclude";
            this._chkExcludeUrl.UseVisualStyleBackColor = true;
            // 
            // _chkExcludeHttpStatus
            // 
            this._chkExcludeHttpStatus.AutoSize = true;
            this._chkExcludeHttpStatus.Location = new System.Drawing.Point(201, 135);
            this._chkExcludeHttpStatus.Name = "_chkExcludeHttpStatus";
            this._chkExcludeHttpStatus.Size = new System.Drawing.Size(64, 17);
            this._chkExcludeHttpStatus.TabIndex = 15;
            this._chkExcludeHttpStatus.Text = "Exclude";
            this._chkExcludeHttpStatus.UseVisualStyleBackColor = true;
            // 
            // _txtHttpStatus
            // 
            this._txtHttpStatus.Location = new System.Drawing.Point(95, 133);
            this._txtHttpStatus.Name = "_txtHttpStatus";
            this._txtHttpStatus.Size = new System.Drawing.Size(100, 20);
            this._txtHttpStatus.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "HTTP Status:";
            // 
            // _chkExcludeUserAgent
            // 
            this._chkExcludeUserAgent.AutoSize = true;
            this._chkExcludeUserAgent.Location = new System.Drawing.Point(201, 161);
            this._chkExcludeUserAgent.Name = "_chkExcludeUserAgent";
            this._chkExcludeUserAgent.Size = new System.Drawing.Size(64, 17);
            this._chkExcludeUserAgent.TabIndex = 18;
            this._chkExcludeUserAgent.Text = "Exclude";
            this._chkExcludeUserAgent.UseVisualStyleBackColor = true;
            // 
            // _txtUserAgent
            // 
            this._txtUserAgent.Location = new System.Drawing.Point(95, 159);
            this._txtUserAgent.Name = "_txtUserAgent";
            this._txtUserAgent.Size = new System.Drawing.Size(100, 20);
            this._txtUserAgent.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "User Agent:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._btnGo);
            this.groupBox3.Controls.Add(this._chkAppendOutputFile);
            this.groupBox3.Controls.Add(this._txtOutputFile);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 452);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(464, 83);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Output File:";
            // 
            // _txtOutputFile
            // 
            this._txtOutputFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._txtOutputFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this._txtOutputFile.Location = new System.Drawing.Point(94, 17);
            this._txtOutputFile.Name = "_txtOutputFile";
            this._txtOutputFile.Size = new System.Drawing.Size(233, 20);
            this._txtOutputFile.TabIndex = 20;
            // 
            // _chkAppendOutputFile
            // 
            this._chkAppendOutputFile.AutoSize = true;
            this._chkAppendOutputFile.Location = new System.Drawing.Point(333, 19);
            this._chkAppendOutputFile.Name = "_chkAppendOutputFile";
            this._chkAppendOutputFile.Size = new System.Drawing.Size(63, 17);
            this._chkAppendOutputFile.TabIndex = 19;
            this._chkAppendOutputFile.Text = "Append";
            this._chkAppendOutputFile.UseVisualStyleBackColor = true;
            // 
            // _btnGo
            // 
            this._btnGo.Location = new System.Drawing.Point(371, 54);
            this._btnGo.Name = "_btnGo";
            this._btnGo.Size = new System.Drawing.Size(75, 23);
            this._btnGo.TabIndex = 21;
            this._btnGo.Text = "GO";
            this._btnGo.UseVisualStyleBackColor = true;
            this._btnGo.Click += new System.EventHandler(this._btnGo_Click);
            // 
            // _chkExcludeQueryString
            // 
            this._chkExcludeQueryString.AutoSize = true;
            this._chkExcludeQueryString.Location = new System.Drawing.Point(200, 107);
            this._chkExcludeQueryString.Name = "_chkExcludeQueryString";
            this._chkExcludeQueryString.Size = new System.Drawing.Size(64, 17);
            this._chkExcludeQueryString.TabIndex = 21;
            this._chkExcludeQueryString.Text = "Exclude";
            this._chkExcludeQueryString.UseVisualStyleBackColor = true;
            // 
            // _txtQueryString
            // 
            this._txtQueryString.Location = new System.Drawing.Point(94, 107);
            this._txtQueryString.Name = "_txtQueryString";
            this._txtQueryString.Size = new System.Drawing.Size(100, 20);
            this._txtQueryString.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Query String:";
            // 
            // dlgMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 547);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "dlgMain";
            this.Text = "IIS Log Filter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _lstFiles;
        private System.Windows.Forms.Button _btnAddFile;
        private System.Windows.Forms.Button _btnAddDirectory;
        private System.Windows.Forms.Button _btnRemoveFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox _chkExcludeUserAgent;
        private System.Windows.Forms.TextBox _txtUserAgent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox _chkExcludeHttpStatus;
        private System.Windows.Forms.TextBox _txtHttpStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox _chkExcludeUrl;
        private System.Windows.Forms.CheckBox _chkExcludeUser;
        private System.Windows.Forms.CheckBox _chkExcludeSourceIP;
        private System.Windows.Forms.TextBox _txtUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtSourceIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox _txtOutputFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button _btnGo;
        private System.Windows.Forms.CheckBox _chkAppendOutputFile;
        private System.Windows.Forms.CheckBox _chkExcludeQueryString;
        private System.Windows.Forms.TextBox _txtQueryString;
        private System.Windows.Forms.Label label7;
    }
}

