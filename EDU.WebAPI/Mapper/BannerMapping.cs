using AutoMapper;
using EDU.DTO.DTOs.BannerDtos;
using EDU.Entity.Entities;

namespace EDU.WebAPI.Mapper
{
    public class BannerMapping:Profile
    {
        public BannerMapping()
        {
            CreateMap<CreateBannerDto, Banner>().ReverseMap();
            CreateMap<UpdateBannerDto, Banner>().ReverseMap();
        }

    }
}
