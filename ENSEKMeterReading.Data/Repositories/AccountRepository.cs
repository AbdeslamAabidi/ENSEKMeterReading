using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ENSEKMeterReading.Core.Models;
using ENSEKMeterReading.Core.Repositories;

namespace ENSEKMeterReading.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(MeterReadingDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await MeterReadingDbContext.Account
                                              .ToListAsync();
        }

        public async Task<Account> GetAccountByIdAsync(long id)
        {
            return await MeterReadingDbContext.Account
                                              .SingleOrDefaultAsync(a => a.AccountId == id);
        }

        private MeterReadingDbContext MeterReadingDbContext
        {
            get { return Context as MeterReadingDbContext; }
        }
    }
}