using AutoMapper;
using EDU.Business.Abstract;
using EDU.Business.Contect;
using EDU.DTO.DTOs.AboutDtos;
using EDU.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> _abautService, IMapper _mapper) : ControllerBase
    {
        private IActionResult OperationControllerMessageShow(object value)
        {
            if (value != null)
                return Ok(Messages.IsSuccess);
            return BadRequest(Messages.NoSuccess);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _abautService.TGetAllAsync();
            if (values.Count > 0)
                return Ok(values);
            return BadRequest(Messages.NotData);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        
        {
            var values = await _abautService.TGetByIdAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _abautService.TDeleteAsync(id);
            return Ok(Messages.IsSuccess);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto about)
        {
            var value = _mapper.Map<About>(about);
            await _abautService.TAddAsync(value);
            if (value != null)
                return Ok(Messages.IsSuccess);
            return BadRequest(Messages.NoSuccess);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto aboutDto)
        {
            var value = _mapper.Map<About>(aboutDto);
            await _abautService.TUpdateAsync(value);
            return OperationControllerMessageShow(value);
        }
    }
}
