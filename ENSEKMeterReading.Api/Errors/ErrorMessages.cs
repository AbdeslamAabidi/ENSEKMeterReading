using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENSEKMeterReading.Api.Errors
{
    public struct ErrorMessages
    {
        public string AccountNoExist
        {
            get => "Account not exist";
        }
        public string EntryAlreadyExist
        {
            get => "Entry already exist";
        }
        public string InvalidMeterReadings
        {
            get => "Invalid Meter Readings.";
        }
    }
}
