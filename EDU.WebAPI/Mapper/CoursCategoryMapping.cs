using AutoMapper;
using EDU.DTO.DTOs.BlogCategoryDtos;
using EDU.DTO.DTOs.CoursCategoryDtos;
using EDU.Entity.Entities;

namespace EDU.WebAPI.Mapper
{
    public class CoursCategoryMapping : Profile
    {
        public CoursCategoryMapping()
        {
            CreateMap<CreateCourseCategoryDto, CoursCategory>().ReverseMap();
            CreateMap<UpdateCourseCategoryDto, CoursCategory>().ReverseMap();
            CreateMap<ResultCoursCategoryDto, CoursCategory>().ReverseMap();
        }
    }
}
