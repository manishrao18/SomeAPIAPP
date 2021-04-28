using AutoMapper;
using SomeAPIAPP.DTOs;
using SomeAPIAPP.Models;

namespace SomeAPIAPP.Profiles
{
    public class SomeAPIAppProfile: Profile
    {
        public SomeAPIAppProfile()
        {// Mapping Source to => Target
            CreateMap<SomeAPIModel, SomeAPIAppReadDTO>();
            CreateMap<SomeAPIAppAddDTO, SomeAPIModel>();
            CreateMap<SomeAPIAppUpdateDTO, SomeAPIModel>();
            CreateMap<SomeAPIModel, SomeAPIAppUpdateDTO>();

        } 
    }
}