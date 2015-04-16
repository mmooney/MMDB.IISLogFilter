using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDB.IisLogFilter.Exe
{
    public class LogItem
    {
        public string RawLogMessage { get; set; }
        public DateTime? Date { get; set; }
        public string UserAgent { get; set; }
        public string SourceIP { get; set; }
        public string UriStem { get; set; }
        public string QueryString { get; set; }
        public string HttpStatus { get; set; }
        public string User { get; set; }
    }
}
