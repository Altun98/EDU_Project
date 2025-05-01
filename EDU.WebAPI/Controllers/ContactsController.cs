using AutoMapper;
using EDU.Business.Abstract;
using EDU.Business.Contect;
using EDU.DTO.DTOs.ContactDtos;
using EDU.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IGenericService<Contact> _contactService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _contactService.TGetAllAsync();
            if (values.Count > 0)
                return Ok(values);
            return BadRequest(Messages.NotData);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _contactService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost("added")]
        public async Task<IActionResult> Added(CreateContactDto contactDto)
        {
            var value = _mapper.Map<Contact>(contactDto);
            await _contactService.TAddAsync(value);
            return Ok(value);
        }
        [HttpPut("updated")]
        public async Task<IActionResult> Updated(UpdateContactDto contactDto)
        {
            var value = _mapper.Map<Contact>(contactDto);
            await _contactService.TUpdateAsync(value);
            return Ok(value);
        }
        [HttpDelete("deleted")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _contactService.TDeleteAsync(id);
            return Ok(Messages.IsSuccess);
        }
    }
}
