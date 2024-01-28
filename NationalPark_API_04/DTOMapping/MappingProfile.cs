using AutoMapper;
using NationalPark_API_04.Model;
using NationalPark_API_04.Model.DTOs;

namespace NationalPark_API_04.DTOMapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<NationalPark,NationalParkDTO>().ReverseMap();
            CreateMap<TrailDTO, Trail>().ReverseMap();
        }
    }
}
