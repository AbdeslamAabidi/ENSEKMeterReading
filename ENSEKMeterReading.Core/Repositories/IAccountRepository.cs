using System.Collections.Generic;
using System.Threading.Tasks;
using ENSEKMeterReading.Core.Models;

namespace ENSEKMeterReading.Core.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(long id);
    }
}