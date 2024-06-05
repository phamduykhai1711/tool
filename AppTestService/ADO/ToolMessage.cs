using System;
using System.Collections.Generic;
using System.Text;

namespace Solomon_Invoice.ADO
{
    class ToolMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public ToolMessage()
        {
            this.Code = "";
            this.Message = "";
        }
    }
}
