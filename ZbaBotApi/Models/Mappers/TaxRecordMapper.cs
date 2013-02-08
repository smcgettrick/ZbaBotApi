using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ZbaBotApi.Models.Mappers
{
    public class TaxRecordMapper
    {
        public static TaxRecord MapToTaxRecord(ZbaBotService.TaxRecord zbaTaxRecord)
        {
            var taxRecord = new TaxRecord
                {
                    RevenueDown = zbaTaxRecord.RevenueDown,
                    TaxInfo = new List<TaxInfo>()
                };

            foreach (var taxInfo in zbaTaxRecord.TaxInfoYears.Select(zbaTaxYear => new TaxInfo
                {
                    Interest = zbaTaxYear.Interest.ToString(CultureInfo.InvariantCulture),
                    Lien = zbaTaxYear.Lien,
                    Other = zbaTaxYear.Other.ToString(CultureInfo.InvariantCulture),
                    Penalty = zbaTaxYear.Penalty.ToString(CultureInfo.InvariantCulture),
                    Principal = zbaTaxYear.Principal.ToString(CultureInfo.InvariantCulture),
                    Solicitor = zbaTaxYear.Solicitor,
                    Status = zbaTaxYear.Status,
                    Total = zbaTaxYear.Total.ToString(CultureInfo.InvariantCulture),
                    Year = zbaTaxYear.Year
                }))
            {
                taxRecord.TaxInfo.Add(taxInfo);
            }
            return taxRecord;
        }
    }
}