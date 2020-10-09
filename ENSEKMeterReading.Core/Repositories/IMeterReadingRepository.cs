using System.Collections.Generic;
using System.Threading.Tasks;
using ENSEKMeterReading.Core.Models;

namespace ENSEKMeterReading.Core.Repositories
{
    public interface IMeterReadingRepository : IRepository<MeterReading>
    {
        Task<IEnumerable<MeterReading>> GetAllMeterReadingAsync();
        Task<MeterReading> GetMeterReadingByIdAsync(long id);
    }
}