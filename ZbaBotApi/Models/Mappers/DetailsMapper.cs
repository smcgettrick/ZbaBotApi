using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZbaBotApi.Models.Mappers
{
    public class DetailsMapper
    {
        public static Details MapToDetails(ZbaBotService.Details opaDetails)
        {
            var details = new Details
                {
                    AssessedImprovementExempt = opaDetails.AssessedImprovementExempt,
                    AssessedImprovementTaxable = opaDetails.AssessedImprovementTaxable,
                    AssessedLandExempt = opaDetails.AssessedLandExempt,
                    AssessedLandTaxable = opaDetails.AssessedLandTaxable,
                    BeginPoint = opaDetails.BeginPoint,
                    Condition = opaDetails.Condition,
                    CouncilDistrict = opaDetails.CouncilDistrict,
                    Description = opaDetails.Description,
                    ImprovementArea = opaDetails.ImprovementArea,
                    LandArea = opaDetails.LandArea,
                    MarketValue = opaDetails.MarketValue,
                    RealEstateTax = opaDetails.RealEstateTax,
                    SaleDate = opaDetails.SaleDate,
                    SalePrice = opaDetails.SalePrice,
                    TotalAssessment = opaDetails.TotalAssessment,
                    Zoning = opaDetails.Zoning,
                    ZoningDescription = opaDetails.ZoningDescription
                };

            return details;
        }
    }
}