using Futurez.Xrm.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futurez.Entities
{
    public class FileUpload
    {
        public FileUpload(string fileNameAndPath) {
            // assume this is a good file
            this.IsIgnored = false;
            this.FullLocalPath = fileNameAndPath;
            this.FileName = Path.GetFileName(fileNameAndPath);

            // evaluate the extension, see if we can set the template type
            var ext = Path.GetExtension(fileNameAndPath);
            switch (ext) {
                case Constants.FILE_EXT_WORD:
                    this.TemplateType = Constants.TEMPL_TYPE_WORD;
                    this.TemplateTypeValue = Constants.TEMPL_TYPE_VAL_WORD;
                    break;
                case Constants.FILE_EXT_EXCEL:
                    this.TemplateType = Constants.TEMPL_TYPE_EXCEL;
                    this.TemplateTypeValue= Constants.TEMPL_TYPE_VAL_EXCEL;
                    break;
                default:
                    // no idea here, ignore it
                    this.IsIgnored = true;
                    this.Note = "Unknown file extension";
                    break;
            }
            if (!this.IsIgnored)
            {
                // use filename only to set template name
                this.TemplateName = Path.GetFileNameWithoutExtension(fileNameAndPath);
            }
        }
        public string FileName { get; private set; }
        public string FullLocalPath { get; private set; }
        public string TemplateType { get; private set; }
        public int TemplateTypeValue { get; private set; }
        public string TemplateName { get; private set; }
        public Guid TemplateId { get; set; }
        public string Note { get; set; }
        public bool IsIgnored { get; set; }
    }
}
