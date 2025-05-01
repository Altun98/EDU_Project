using AutoMapper;
using EDU.DTO.DTOs.ContactDtos;
using EDU.Entity.Entities;

namespace EDU.WebAPI.Mapper
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
        }
    }
}
