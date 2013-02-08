using System.Linq;
using ZbaBotApi.ZbaBotService;

namespace ZbaBotApi.Models.Mappers
{
    public class AccountMapper
    {
        public static Account MapToAccount(OPAAccount zbaAccount)
        {
            var account = new Account
                {
                    AccountNumber = zbaAccount.AccountNumber,
                    Address = zbaAccount.Address,
                    Details = DetailsMapper.MapToDetails(zbaAccount.Details),
                    Owner = OwnerMapper.MapToOwner(zbaAccount.Owner),
                    SuggesstedAddresses = zbaAccount.SuggestedAddresses == null ? null : AddressMapper.MapToAddress(zbaAccount.SuggestedAddresses.ToList()),
                    SuggestedProperties = zbaAccount.SuggestedProperties == null ? null : PropertyMapper.MapToProperty(zbaAccount.SuggestedProperties.ToList()),
                    TaxRecord = TaxRecordMapper.MapToTaxRecord(zbaAccount.TaxRecord),
                    UnitNumber = zbaAccount.UnitNumber,
                    ValuationRecord = ValuationMapper.MapToValuationRecord(zbaAccount.Valuation),
                    ZipCode = zbaAccount.Zip
                };

            return account;
        }
    }
}