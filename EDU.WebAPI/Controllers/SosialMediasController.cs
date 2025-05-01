using AutoMapper;
using EDU.Business.Abstract;
using EDU.Business.Contect;
using EDU.DTO.DTOs.SocialMediaDtos;
using EDU.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SosialMediasController(IGenericService<SocialMedia> _sosialMediaService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _sosialMediaService.TGetAllAsync();
            if (values.Count > 0)
                return Ok(values);
            return Ok(Messages.NotData);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _sosialMediaService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost("added")]
        public async Task<IActionResult> Added(CreateSocialMediaDto socialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(socialMediaDto);
            await _sosialMediaService.TAddAsync(value);
            if (value != null)
                return Ok(Messages.IsSuccess);
            return Ok(Messages.NoSuccess);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Updated(UpdateSocialMediaDto updateSocialMedia)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMedia);
            await _sosialMediaService.TUpdateAsync(value);
            if (value != null)
                return Ok(Messages.IsSuccess);
            return Ok(Messages.NoSuccess);
        }
        [HttpDelete("deleted")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _sosialMediaService.TDeleteAsync(id);
            return Ok(Messages.IsSuccess);
        }
    }
}
