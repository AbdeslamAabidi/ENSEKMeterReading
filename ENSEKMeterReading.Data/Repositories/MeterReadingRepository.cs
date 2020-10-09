using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ENSEKMeterReading.Core.Models;
using ENSEKMeterReading.Core.Repositories;

namespace ENSEKMeterReading.Data.Repositories
{
    public class MeterReadingRepository : Repository<MeterReading>, IMeterReadingRepository
    {
        public MeterReadingRepository(MeterReadingDbContext context) 
            : base(context)
        { }

        private MeterReadingDbContext MeterReadingDbContext
        {
            get { return Context as MeterReadingDbContext; }
        }

        public async Task<IEnumerable<MeterReading>> GetAllMeterReadingAsync()
        {
            return await MeterReadingDbContext.MeterReading
                                              .ToListAsync();
        }

        public async Task<MeterReading> GetMeterReadingByIdAsync(long id)
        {
            return await MeterReadingDbContext.MeterReading
                                              .SingleOrDefaultAsync(m => m.AccountId == id);
        }
    }
}