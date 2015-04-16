using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDB.IisLogFilter.Exe
{
    public class FileListItem
    {
        public string Path { get; set; }
        public bool IsDirectory { get; set; }
        public bool RecurseDirectories { get; set; }

        public string DisplayValue
        {
            get 
            {
                if(this.IsDirectory)
                {
                    if(this.RecurseDirectories)
                    {
                        return this.Path + @"\**\*.*";
                    }
                    else 
                    {
                        return this.Path + @"\*.*";
                    }
                }
                else 
                {
                    return this.Path;
                }
            }
        }
    }
}
