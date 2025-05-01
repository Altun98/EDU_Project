using AutoMapper;
using EDU.Business.Abstract;
using EDU.Business.Contect;
using EDU.DTO.DTOs.MessageDtos;
using EDU.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IGenericService<Message> _messageService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _messageService.TGetAllAsync();
            if (values.Count > 0)
                return Ok(values);
            return Ok(Messages.NotData);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByID(int id)
        {
            var value = await _messageService.TGetByIdAsync(id);
            if (value != null)
                return Ok(value);
            return Ok(Messages.NotData);
        }
        [HttpPost("added")]
        public async Task<IActionResult> Added(CreateMessageDto createMessage)
        {
            var value = _mapper.Map<Message>(createMessage);
            await _messageService.TAddAsync(value);
            return Ok(value);
        }
        [HttpPut("updated")]
        public async Task<IActionResult> Updated(UpdateMessageDto messageDto)
        {
            var value = _mapper.Map<Message>(messageDto);
            await _messageService.TUpdateAsync(value);
            return Ok(Messages.IsSuccess);
        }
        [HttpDelete("deleted")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _messageService.TDeleteAsync(id);
            return Ok(Messages.IsSuccess);
        }
    }
}
