using AutoMapper;
using EDU.DTO.DTOs.TestimonialDtos;
using EDU.Entity.Entities;

namespace EDU.WebAPI.Mapper
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
        }
    }
}
