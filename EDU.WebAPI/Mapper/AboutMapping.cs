using AutoMapper;
using EDU.DTO.DTOs.AboutDtos;
using EDU.Entity.Entities;

namespace EDU.WebAPI.Mapper
{
    public class AboutMapping:Profile
    {
        public AboutMapping()
        {
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
        }
    }
}
