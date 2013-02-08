using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZbaBotApi.Models
{
    public class Owner
    {
        public string Name { get; set; }
        public string MailingAddress1 { get; set; }
        public string MailingAddress2 { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZipCode { get; set; }
    }
}