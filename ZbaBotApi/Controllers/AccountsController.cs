using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZbaBotApi.Models;
using ZbaBotApi.Models.Repositories;

namespace ZbaBotApi.Controllers
{
    public class AccountsController : ApiController
    {
        private readonly IAccountRepository _repository;

        public AccountsController(IAccountRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            _repository = repository;
        }

        /// <summary>
        /// Get OPA Account by Account Number.
        /// </summary>
        /// <param name="accountNumber">The OPA Account Number.</param>
        /// <returns>The OPA Account associated with the Account Number.</returns>
        public Account GetAccountByAccountNumber(string accountNumber)
        {
            var account = _repository.GetByAccountNumber(accountNumber);

            if (account == null)
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.NotFound)
                        {
                            Content = new StringContent(string.Format("No account found with Account Number = {0}", accountNumber)),
                            ReasonPhrase = "Account Number Not Found"
                        });

            return account;
        }

        /// <summary>
        /// Get OPA Account by Owner Name.
        /// </summary>
        /// <param name="ownerName">The Owner Name.</param>
        /// <returns>The OPA Account associated with the Owner Name.</returns>
        public Account GetAccountByOwnerName(string ownerName)
        {
            var account = _repository.GetByOwnerName(ownerName);

            if (account == null)
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.NotFound)
                        {
                            Content = new StringContent(string.Format("No account found with Owner Name = {0}", ownerName)),
                            ReasonPhrase = "Owner Name Not Found"
                        });

            return account;
        }

        /// <summary>
        /// Get OPA Account by Address.
        /// </summary>
        /// <param name="address">The Address.</param>
        /// <returns>The OPA Account associated with the Address.</returns>
        public Account GetAccountByAddress(string address)
        {
            var account = _repository.GetByAddress(address);

            if (account == null)
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.NotFound)
                        {
                            Content = new StringContent(string.Format("No account found with Address = {0}", address)),
                            ReasonPhrase = "Address Not Found"
                        });

            return account;
        }
    }
}
