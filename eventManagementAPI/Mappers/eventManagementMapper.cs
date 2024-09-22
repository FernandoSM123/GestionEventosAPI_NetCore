using AutoMapper;
using eventManagementAPI.DTOs;
using eventManagementAPI.DTOs.LocationDTOs;
using eventManagementAPI.DTOs.UserDTOs;
using eventManagementAPI.DTOs.EventDTOs;
using eventManagementAPI.Models;

namespace eventManagementAPI.Mappers
{
    public class eventManagementMapper : Profile
    {
        public eventManagementMapper()
        {
            //Users
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserType, UserTypeDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();

            //Locations
            CreateMap<Province, ProvinceDTO>().ReverseMap();
            CreateMap<Canton, CantonDTO>().ReverseMap();
            CreateMap<District, DistrictDTO>().ReverseMap();

            //Event
            CreateMap<Event, EventDTO>()
            .ForMember(dest => dest.province, opt => opt.MapFrom(src => src.province))
            .ForMember(dest => dest.canton, opt => opt.MapFrom(src => src.canton))
            .ForMember(dest => dest.district, opt => opt.MapFrom(src => src.district))
            .ReverseMap();


            CreateMap<Event, CreateEventDTO>().ReverseMap();


            CreateMap<Event, UpdateEventDTO>().ReverseMap();
        }
    }
}
