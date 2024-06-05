using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolomonInvoice
{
    public class AttachResult
    {
        public Item Item { get; set; }
    }
    public class Item
    {
        public List<AttachFiles> AttachFiles { get; set; }
    }

    public class AttachFiles
    {
        public string AttachContentBase64 { get; set; }
        public string AttachFileName { get; set; }
    }

    public class ExtraFields
    {
        public string FieldName { get; set; }

        public string FieldValue { get; set; }
    }

}
