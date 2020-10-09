using System.Collections.Generic;
using System.Threading.Tasks;
using ENSEKMeterReading.Core.Models;

namespace ENSEKMeterReading.Core.Services
{
    public interface IMeterReadingService
    {
        Task<IEnumerable<MeterReading>> GetAllMeterReading();
        Task<MeterReading> GetMeterReadingById(long id);
        IEnumerable<MeterReading> GetAllMeterReadingById(long id);
        Task<MeterReading> CreateMeterReading(MeterReading newMeterReading);
        Task UpdateMeterReading(MeterReading meterReadingToBeUpdated, MeterReading meterReading);        
    }
}