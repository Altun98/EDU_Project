using AutoMapper;
using EDU.DTO.DTOs.BlogDtos;
using EDU.Entity.Entities;

namespace EDU.WebAPI.Mapper
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<CreateBlogDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            CreateMap<ResultBlogDto, Blog>().ReverseMap();
        }
    }
}
