using AutoMapper;
using EDU.DTO.DTOs.MessageDtos;
using EDU.Entity.Entities;

namespace EDU.WebAPI.Mapper
{
    public class MessageMapping:Profile
    {
        public MessageMapping()
        {
            CreateMap<CreateMessageDto, Message>().ReverseMap();
            CreateMap<UpdateMessageDto, Message>().ReverseMap();
        }
    }
}
