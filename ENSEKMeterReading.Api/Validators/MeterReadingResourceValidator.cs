using ENSEKMeterReading.Api.Errors;
using ENSEKMeterReading.Api.Resources;
using FluentValidation;
using System;

namespace ENSEKMeterReading.Api.Validations
{
    public class MeterReadingResourceValidator : AbstractValidator<MeterReadingResource>
    {
        private readonly ErrorMessages errorMessages;

        public MeterReadingResourceValidator()
        {
            RuleFor(m => m.AccountId).NotEmpty().NotNull();

            RuleFor(m => m.MeterReadingDateTime).NotEmpty();

            RuleFor(m => m.MeterReadValue).Must(ValidateMeterReading)
                                          .WithMessage(errorMessages.InvalidMeterReadings);
        }

        private bool ValidateMeterReading(string value)
        {
            var isNumeric = Int64.TryParse(value, out long meterReading);

            if(!isNumeric 
                || value.Length > 5 
                || (meterReading < 0 || meterReading > 99999) ) {
                return false;
            }

            return true;
        }
    }
}