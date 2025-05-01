using AutoMapper;
using EDU.Business.Abstract;
using EDU.Business.Contect;
using EDU.DataAccess.Abstract;
using EDU.DTO.DTOs.BannerDtos;
using EDU.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _bannerService.TGetAllAsync();
            if (values.Count > 0)
                return Ok(values);
            return BadRequest(Messages.NotData);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _bannerService.TGetByIdAsync(id);
            if (value != null)
                return Ok(value);
            return BadRequest(Messages.NotData);
        }
        [HttpPost("added")]
        public async Task<IActionResult> Added(CreateBannerDto bannerDto)
        {
            var value = _mapper.Map<Banner>(bannerDto);
            await _bannerService.TAddAsync(value);
            return Ok(value);
        }
        [HttpPut("updated")]
        public async Task<IActionResult> Updated(UpdateBannerDto bannerDto)
        {
            var value = _mapper.Map<Banner>(bannerDto);
            await _bannerService.TUpdateAsync(value);
            return Ok(value);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Deleted(int id)
        {
            var value = _bannerService.TDeleteAsync(id);
            return Ok(Messages.IsSuccess);
        }

    }
}
