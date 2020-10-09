using System.Collections.Generic;
using System.Threading.Tasks;
using ENSEKMeterReading.Core;
using ENSEKMeterReading.Core.Models;
using ENSEKMeterReading.Core.Services;

namespace ENSEKMeterReading.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Account> GetAccountById(long id)
        {
            return await _unitOfWork.Account.GetAccountByIdAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _unitOfWork.Account.GetAllAccountsAsync();
        }
    }
}
