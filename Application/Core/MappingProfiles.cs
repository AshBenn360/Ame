using Application.Quotations;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
           
            CreateMap<AppInformation, ApplicationInformationDto>();
        }
    }
}