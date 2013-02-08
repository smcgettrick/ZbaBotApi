using System.Collections.Generic;
using System.Linq;

namespace ZbaBotApi.Models.Mappers
{
    public class AddressMapper
    {
        public static List<Address> MapToAddress(List<ZbaBotService.SuggestedAddress> zbaAddresses)
        {
            return zbaAddresses.Select(zbaAddress => new Address {AddressName = zbaAddress.AddressName}).ToList();
        }
    }
}