using AutoMapper;
using EDU.DTO.DTOs.CourseDtos;
using EDU.Entity.Entities;

namespace EDU.WebAPI.Mapper
{
    public class CoursMapping:Profile
    {
        public CoursMapping()
        {
            CreateMap<CreateCoursDto, Course>().ReverseMap();
            CreateMap<UpdateCoursDto, Course>().ReverseMap();
            CreateMap<ResultCoursDto, Course>().ReverseMap();
        }
    }
}
