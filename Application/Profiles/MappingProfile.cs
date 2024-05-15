using AutoMapper;
using Entities.Dto;
using Entities.Models;
using WebScrapperLibrary;

namespace Application.Profiles
{
    public class MappingProfile : Profile {
        public MappingProfile()
        {

            //for creation
            CreateMap<ScrappedDataForCreationDto, ScrappedData>();
            CreateMap<Product, ScrappedData>();

            

        }
    }
    
}