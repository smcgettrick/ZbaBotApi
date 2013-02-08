using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbaBotApi.Models.Repositories
{
    public interface IAccountRepository
    {
        Account GetByAccountNumber(string accountNumber);
        Account GetByOwnerName(string ownerName);
        Account GetByAddress(string address);
    }
}
