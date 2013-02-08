using System.Collections.Generic;

namespace ZbaBotApi.Models
{
    public class TaxRecord
    {
        public List<TaxInfo> TaxInfo { get; set; }
        public bool RevenueDown { get; set; }
    }
}