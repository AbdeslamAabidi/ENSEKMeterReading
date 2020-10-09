using System.Collections.Generic;
using System.Threading.Tasks;
using ENSEKMeterReading.Core;
using ENSEKMeterReading.Core.Models;
using ENSEKMeterReading.Core.Services;

namespace ENSEKMeterReading.Services
{
    public class MeterReadingService : IMeterReadingService 
    {
        private readonly IUnitOfWork _unitOfWork;
        public MeterReadingService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<MeterReading> CreateMeterReading(MeterReading newMeterReading)
        {
            await _unitOfWork.MeterReading
                             .AddAsync(newMeterReading);

            await _unitOfWork.CommitAsync();
            
            return newMeterReading;
        }

        public async Task UpdateMeterReading(MeterReading meterReadingToBeUpdated, MeterReading meterReading)
        {
            meterReadingToBeUpdated.MeterReadingDateTime = meterReading.MeterReadingDateTime;
            meterReadingToBeUpdated.MeterReadValue = meterReading.MeterReadValue;

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<MeterReading>> GetAllMeterReading()
        {
            return await _unitOfWork.MeterReading.GetAllMeterReadingAsync();
        }

        public async Task<MeterReading> GetMeterReadingById(long id)
        {
            return await _unitOfWork.MeterReading.GetMeterReadingByIdAsync(id);
        }

        public IEnumerable<MeterReading> GetAllMeterReadingById(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
