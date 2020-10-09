using AutoMapper;
using ENSEKMeterReading.Api.Resources;
using ENSEKMeterReading.Core.Models;

namespace ENSEKMeterReading.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<MeterReading, MeterReadingResource>();
            
            // Resource to Domain
            CreateMap<MeterReadingResource, MeterReading>().ForMember(dest => dest.MeterReadValue, opt => opt.AddTransform(n => n.PadLeft(5, '0')));

            // to Report
            //CreateMap<MeterReading, MeterReading>();

        }
    }
}