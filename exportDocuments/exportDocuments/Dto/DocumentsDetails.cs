using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danaosDocuments.Dto
{
    public class DocumentsDetails
    {

        public string Name { get; set; }
        public string EscapedName { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }
        public string LastModified { get; set; }
        public string ChangeTimeUtc { get; set; }
        public string ChangeTime { get; set; }
        public string CreatedUtc { get; set; }
        public string CreatedDisplayValue { get; set; }
        public string LastModifiedDisplayValue { get; set; }
        public string FileGUID { get; set; }
        public string ID { get; set; }
        public string Version { get; set; }
        public string FileVersionType { get; set; }
    }
}
