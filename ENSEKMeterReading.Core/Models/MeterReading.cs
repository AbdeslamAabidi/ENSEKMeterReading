using System;

namespace ENSEKMeterReading.Core.Models
{
    public class MeterReading
    {
        public long AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public string MeterReadValue { get; set; }
    }
}