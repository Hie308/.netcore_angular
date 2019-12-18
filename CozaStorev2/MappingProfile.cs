using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CozaStorev2.Models;
using EntityModel.DTO;
namespace CozaStorev2
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Devices, DeviceDto>();

            CreateMap<Users, UserDto>();

            CreateMap<DeviceDto, DeviceForCreationDto>();
            CreateMap<Devices, DeviceDto>();
            CreateMap<DeviceDto, Devices>();
            CreateMap<DeviceForCreationDto, Devices>();

            CreateMap<Locations, LocationDto>();
            CreateMap<LocationDto, LocationForCreationDto>();

            CreateMap<Users, UserDto>();
            CreateMap<UserDto, UserForCreationDto>();
          

        }
    }
}
