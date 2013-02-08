using System;
using ZbaBotApi.Models.Mappers;
using ZbaBotApi.ZbaBotService;

namespace ZbaBotApi.Models.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private static readonly ServiceSoap Service = new ServiceSoapClient();

        public Account GetByAccountNumber(string accountNumber)
        {
            var request = new GetOPAAccountByAccountNumberRequest
            {
                Body = new GetOPAAccountByAccountNumberRequestBody(accountNumber)
            };
            var response =
                Service.GetOPAAccountByAccountNumber(request).Body.GetOPAAccountByAccountNumberResult;

            return response == null ? null : AccountMapper.MapToAccount(response);
        }

        public Account GetByOwnerName(string ownerName)
        {
            var request = new GetOPAAccountByAccountOwnerRequest
                {
                    Body = new GetOPAAccountByAccountOwnerRequestBody(ownerName)
                };
            var response =
                Service.GetOPAAccountByAccountOwner(request).Body.GetOPAAccountByAccountOwnerResult;

            return response == null ? null : AccountMapper.MapToAccount(response);
        }

        public Account GetByAddress(string address)
        {
            var request = new GetOPAAccountByStreetAddressRequest
                {
                    Body = new GetOPAAccountByStreetAddressRequestBody(address)
                };
            var response =
                Service.GetOPAAccountByStreetAddress(request).Body.GetOPAAccountByStreetAddressResult;

            return response == null ? null : AccountMapper.MapToAccount(response);
        }
    }
}