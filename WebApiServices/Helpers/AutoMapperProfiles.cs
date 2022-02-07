using AutoMapper;
using WebApiServices.Dtos;
using WebApiServices.Models;

namespace WebApiServices.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(){
            //CreateMap<City, CityDto>();  -> za getAllCities
            //reateMap<CityDto, City>();   -> za Add
            CreateMap<City, CityDto>().ReverseMap();

            CreateMap<City, CityUpdateDto>().ReverseMap();
          
        }
    }
}