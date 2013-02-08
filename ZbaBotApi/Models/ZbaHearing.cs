using System;

namespace ZbaBotApi.Models
{
    public class ZbaHearing
    {
        public int Id { get; set; }
        public string CalendarNumber { get; set; }
        public string ApplicationNumber { get; set; }
        public string ZoningCategory { get; set; }
        public string ParcelType { get; set; }
        public string Proposal { get; set; }
        public string Owner { get; set; }
        public string Applicant { get; set; }
        public string Attorney { get; set; }
        public string HearingDate { get; set; }
        public string AppealDate { get; set; }
        public string Address { get; set; }
        public string FullAddress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool TaxDelinquent { get; set; }
    }
}