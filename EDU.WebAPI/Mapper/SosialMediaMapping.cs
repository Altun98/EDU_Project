using AutoMapper;
using EDU.DTO.DTOs.SocialMediaDtos;
using EDU.Entity.Entities;

namespace EDU.WebAPI.Mapper
{
    public class SosialMediaMapping:Profile
    {
        public SosialMediaMapping()
        {
            CreateMap<CreateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto, SocialMedia>().ReverseMap();
        }
    }
}
