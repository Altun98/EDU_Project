using AutoMapper;
using EDU.DTO.DTOs.SubscriberDtos;
using EDU.Entity.Entities;

namespace EDU.WebAPI.Mapper
{
    public class SubscriberMapping:Profile
    {
        public SubscriberMapping()
        {
            CreateMap<CreateSubscriberDto, Subscriber>().ReverseMap();
            CreateMap<UpdateSubscriberDto, Subscriber>().ReverseMap();
        }
    }
}
