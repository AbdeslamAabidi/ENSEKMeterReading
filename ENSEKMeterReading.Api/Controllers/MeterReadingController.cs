using AutoMapper;
using ENSEKMeterReading.Api.Errors;
using ENSEKMeterReading.Api.Reports;
using ENSEKMeterReading.Api.Resources;
using ENSEKMeterReading.Api.Validations;
using ENSEKMeterReading.Core.Models;
using ENSEKMeterReading.Core.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENSEKMeterReading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadingController : ControllerBase
    {
        private readonly IMeterReadingService _meterReadingService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private MeterReadingReport _meterReadingReport;
        private readonly ErrorMessages errorMessages;

        public MeterReadingController(IMeterReadingService meterReadingService
                                    , IAccountService accountService
                                    , IMapper mapper) {
            _mapper = mapper;
            _meterReadingService = meterReadingService;
            _accountService = accountService;
        }

        [HttpPost("")]
        public async Task<ActionResult<MeterReadingResource>> CreateMeterReading([FromBody] List<MeterReadingResource> meterReadingResourceList)
        {
            _meterReadingReport = new MeterReadingReport();

            var validator = new MeterReadingResourceValidator();

            foreach (var meterReadingResource in meterReadingResourceList.ToList())
            {
                var validationResult = await validator.ValidateAsync(meterReadingResource);
                if (!validationResult.IsValid)
                {
                    _meterReadingReport.AddToMeterReadingValidationReport(meterReadingResource
                                                                        , validationResult.Errors
                                                                                            .Select(n => n.ErrorMessage)
                                                                        , MeterReadingStatusReport.Failed);

                    meterReadingResourceList.Remove(meterReadingResource);
                }
            }

            foreach (var meterReadingResource in meterReadingResourceList.ToList())
            {
                var toMeterReading = _mapper.Map<MeterReadingResource, MeterReading>(meterReadingResource);

                var account = await _accountService.GetAccountById(toMeterReading.AccountId);
                if (account == null)
                {
                    _meterReadingReport.AddToMeterReadingValidationReport(meterReadingResource
                                                                        , new List<string> { errorMessages.AccountNoExist }
                                                                        , MeterReadingStatusReport.Failed);

                    meterReadingResourceList.Remove(meterReadingResource);
                    continue;
                }

                var meterReading = await _meterReadingService.GetMeterReadingById(toMeterReading.AccountId);

                if (meterReading != null)
                {
                    _meterReadingReport.AddToMeterReadingValidationReport(meterReadingResource
                                                                        , new List<string> { errorMessages.EntryAlreadyExist }
                                                                        , MeterReadingStatusReport.Failed);

                    meterReadingResourceList.Remove(meterReadingResource);
                }
                else
                {
                    await CreateMeterReading(toMeterReading);
                }
            }

            return Ok(_meterReadingReport);
        }

        private async Task CreateMeterReading(MeterReading meterReading)
        {
            var newMeterReading = await _meterReadingService.CreateMeterReading(meterReading);
            var toMeterReadingResource = _mapper.Map<MeterReading, MeterReadingResource>(newMeterReading);

            _meterReadingReport.AddToMeterReadingValidationReport(toMeterReadingResource);
        }
    }
}