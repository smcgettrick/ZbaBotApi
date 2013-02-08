using System;

namespace ZbaBotApi.Models
{
    public class Details
    {
        public string LandArea { get; set; }
        public string ImprovementArea { get; set; }
        public string Description { get; set; }
        public string Zoning { get; set; }
        public string ZoningDescription { get; set; }
        public string Condition { get; set; }
        public string CouncilDistrict { get; set; }
        public string BeginPoint { get; set; }
        public string MarketValue { get; set; }
        public string RealEstateTax { get; set; }
        public string TotalAssessment { get; set; }
        public string AssessedLandTaxable { get; set; }
        public string AssessedImprovementTaxable { get; set; }
        public string AssessedLandExempt { get; set; }
        public string AssessedImprovementExempt { get; set; }
        public string SaleDate { get; set; }
        public string SalePrice { get; set; }
    }
}