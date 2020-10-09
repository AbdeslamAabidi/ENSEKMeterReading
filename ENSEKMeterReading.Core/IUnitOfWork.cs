using System;
using System.Threading.Tasks;
using ENSEKMeterReading.Core.Repositories;

namespace ENSEKMeterReading.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Account { get; }
        IMeterReadingRepository MeterReading { get; }
        Task<int> CommitAsync();
    }
}