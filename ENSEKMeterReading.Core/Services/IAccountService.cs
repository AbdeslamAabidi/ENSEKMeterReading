using System.Collections.Generic;
using System.Threading.Tasks;
using ENSEKMeterReading.Core.Models;

namespace ENSEKMeterReading.Core.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountById(long id);
    }
}