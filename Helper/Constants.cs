using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futurez.Xrm.Tools
{
    public class Constants
    {
        public const int TEMPL_TYPE_VAL_WORD = 2;
        public const int TEMPL_TYPE_VAL_EXCEL = 1;
        public const string TEMPL_TYPE_WORD = "Microsoft Word";
        public const string TEMPL_TYPE_EXCEL = "Microsoft Excel";
        public const string FILE_EXT_WORD = ".docx";
        public const string FILE_EXT_EXCEL = ".xlsx";
        public const string FILE_DLG_FILTER_ALL_FILES = "All files (*.*)|*.*";

        public static string GetFileOpenFilter() {
            var filter = string.Format("{0} (*{1})|*{1}|{2} (*{3})|*{3}|{4}",
                    Constants.TEMPL_TYPE_WORD,
                    Constants.FILE_EXT_WORD,
                    Constants.TEMPL_TYPE_EXCEL,
                    Constants.FILE_EXT_EXCEL,
                    Constants.FILE_DLG_FILTER_ALL_FILES
                );

            return filter;
        }
    }
}
