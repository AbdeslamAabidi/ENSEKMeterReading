using System;

namespace ENSEKMeterReading.Api.Resources
{
    public class MeterReadingResource
    {
        public long AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public string MeterReadValue { get; set; }  
    }
}
