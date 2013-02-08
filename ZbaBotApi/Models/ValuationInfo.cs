using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZbaBotApi.Models
{
    public class ValuationInfo
    {
        public string Year { get; set; }
        public string MarketValue { get; set; }
        public string AssessedLandTaxable { get; set; }
        public string AssessedImprovementTaxable { get; set; }
        public string AssessedLandExempt { get; set; }
        public string AssessedImprovementExempt { get; set; }
        public string TotalAssessment { get; set; }
        public string GrossTax { get; set; }
    }
}