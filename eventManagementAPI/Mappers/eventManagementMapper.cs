using AutoMapper;
using eventManagementAPI.DTOs;
using eventManagementAPI.DTOs.LocationDTOs;
using eventManagementAPI.DTOs.UserDTOs;
using eventManagementAPI.Models;

namespace eventManagementAPI.Mappers
{
    public class eventManagementMapper : Profile
    {
        public eventManagementMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserType, UserTypeDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();

            CreateMap<Province, ProvinceDTO>().ReverseMap();
            CreateMap<Canton, CantonDTO>().ReverseMap();
            CreateMap<District, DistrictDTO>().ReverseMap();
        }
    }
}
