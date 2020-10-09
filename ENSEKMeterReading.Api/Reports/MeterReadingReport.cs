using ENSEKMeterReading.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ENSEKMeterReading.Api.Reports
{
    public enum MeterReadingStatusReport
    {
        Successfull,
        Failed
    }

    public class MeterReadingErrorMessages
    {
        public long AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public string MeterReadValue { get; set; }
        public List<string> Messages { get; set; }
    }

    public class MeterReadingReport
    {
        public List<MeterReadingErrorMessages> Successfull { get; set; }
        public List<MeterReadingErrorMessages> Failed { get; set; }

        public MeterReadingReport()
        {
            Successfull = new List<MeterReadingErrorMessages>();
            Failed = new List<MeterReadingErrorMessages>();
        }

        public void AddToMeterReadingValidationReport(MeterReadingResource meterReadingResource
                                                    , IEnumerable<string> errors = null
                                                    , MeterReadingStatusReport type = MeterReadingStatusReport.Successfull)
        {
            var meterReadingErrorMessages = new MeterReadingErrorMessages
            {
                AccountId = meterReadingResource.AccountId,
                MeterReadingDateTime = meterReadingResource.MeterReadingDateTime,
                MeterReadValue = meterReadingResource.MeterReadValue,
                Messages = errors?.ToList()
            };

            if (type == MeterReadingStatusReport.Successfull)
            {
                Successfull.Add(meterReadingErrorMessages);
            }
            else
            {
                Failed.Add(meterReadingErrorMessages);
            }
        }
    }
}
