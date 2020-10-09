using ENSEKMeterReading.Api.Resources;
using ENSEKMeterReading.Api.Validations;
using System;
using Xunit;

namespace ENSEKMeterReading.Test
{
    public class ValidationRuleTest
    {
        [Fact]
        public async System.Threading.Tasks.Task TestMeterReadingAsync()
        {
            //Arrange
            var meterReadingResource = new MeterReadingResource() {
                AccountId = 2344,
                MeterReadingDateTime = DateTime.Parse("22/04/2019 09:24"),
                MeterReadValue = "01002"
            };
            var validator = new MeterReadingResourceValidator();

            //Act
            var validationResult = await validator.ValidateAsync(meterReadingResource);

            //Assert
            Assert.True(validationResult.IsValid, "Not valid");
        }
    }
}
