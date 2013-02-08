using System.Collections.Generic;
using System.Linq;

namespace ZbaBotApi.Models.Mappers
{
    public class ValuationMapper
    {
        public static ValuationRecord MapToValuationRecord(ZbaBotService.Valuation zbaValuationRecord)
        {
            var valuationRecord = new ValuationRecord
                {
                    ValuationInfo = new List<ValuationInfo>()
                };

            foreach (var valuation in zbaValuationRecord.ValuationYears.Select(zbaValuation => new ValuationInfo
                {
                    AssessedImprovementExempt = zbaValuation.AssessedImprovementExempt,
                    AssessedImprovementTaxable = zbaValuation.AssessedImprovementTaxable,
                    AssessedLandExempt = zbaValuation.AssessedLandExempt,
                    AssessedLandTaxable = zbaValuation.AssessedLandTaxable,
                    GrossTax = zbaValuation.GrossTax,
                    MarketValue = zbaValuation.MarketValue,
                    TotalAssessment = zbaValuation.TotalAssessment,
                    Year = zbaValuation.Year
                }))
            {
                valuationRecord.ValuationInfo.Add(valuation);
            }

            return valuationRecord;
        }
    }
}