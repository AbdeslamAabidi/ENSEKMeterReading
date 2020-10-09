using System.Threading.Tasks;
using ENSEKMeterReading.Core;
using ENSEKMeterReading.Core.Repositories;
using ENSEKMeterReading.Data.Repositories;

namespace ENSEKMeterReading.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeterReadingDbContext _context;

        private AccountRepository _accountRepository;
        private MeterReadingRepository _meterReadingRepository;

        public UnitOfWork(MeterReadingDbContext context)
        {
            _context = context;
        }

        public IAccountRepository Account => _accountRepository = _accountRepository ?? new AccountRepository(_context);

        public IMeterReadingRepository MeterReading => _meterReadingRepository = _meterReadingRepository ?? new MeterReadingRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}