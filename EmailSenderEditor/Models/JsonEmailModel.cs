using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderEditor
{
    public class JsonEmailModel
    {
        public string senderEmail { get; set; }
        public string senderPassword { get; set; }
        public string recipientEmail { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
}
