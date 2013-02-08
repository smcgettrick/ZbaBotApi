using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZbaBotApi.Models
{
    public class TaxInfo
    {
        public string Year { get; set; }
        public string Principal { get; set; }
        public string Interest { get; set; }
        public string Penalty { get; set; }
        public string Other { get; set; }
        public string Total { get; set; }
        public string Lien { get; set; }
        public string Solicitor { get; set; }
        public string Status { get; set; }
    }
}