using AutoMapper;
using EDU.Business.Abstract;
using EDU.Business.Contect;
using EDU.DTO.DTOs.SubscriberDtos;
using EDU.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericService<Subscriber> _subscribeService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _subscribeService.TGetAllAsync();
            if (values.Count > 0)
                return Ok(values);
            return Ok(Messages.NotData);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _subscribeService.TGetByIdAsync(id);
            if (value != null)
                return Ok(value);
            return Ok(Messages.NotData);
        }
        [HttpPost("added")]
        public async Task<IActionResult> Added(CreateSubscriberDto subscriberDto)
        {
            var value = _mapper.Map<Subscriber>(subscriberDto);
            await _subscribeService.TAddAsync(value);
            if (value != null)
                return Ok(Messages.IsSuccess);
            return Ok(Messages.NoSuccess);
        }
        [HttpPut("updated")]
        public async Task<IActionResult> Updated(UpdateSubscriberDto subscriberDto)
        {
            var value = _mapper.Map<Subscriber>(subscriberDto);
            await _subscribeService.TUpdateAsync(value);
            if (value != null)
                return Ok(Messages.IsSuccess);
            return Ok(Messages.NoSuccess);
        }
        [HttpDelete("deleted")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _subscribeService.TDeleteAsync(id);
            return Ok(Messages.IsSuccess);
        }
    }
}
