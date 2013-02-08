using System.Collections.Generic;

namespace ZbaBotApi.Models
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string Address { get; set; }
        public string UnitNumber { get; set; }
        public string ZipCode { get; set; }
        public List<Property> SuggestedProperties { get; set; }
        public List<Address> SuggesstedAddresses { get; set; }
        public TaxRecord TaxRecord { get; set; }
        public ValuationRecord ValuationRecord { get; set; }
        public Owner Owner { get; set; }
        public Details Details { get; set; }
    }
}