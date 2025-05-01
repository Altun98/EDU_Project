using AutoMapper;
using EDU.Business.Abstract;
using EDU.Business.Contect;
using EDU.DTO.DTOs.CoursCategoryDtos;
using EDU.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursCategorysController(IGenericService<CoursCategory> _coursCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _coursCategoryService.TGetAllAsync();
            if (values.Count > 0)
                return Ok(values);
            return Ok(Messages.NotData);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetbyID(int id)
        {
            var value = await _coursCategoryService.TGetByIdAsync(id);
            if (value != null)
                return Ok(value);
            throw new Exception("melumat yoxdur");
        }
        [HttpPost("added")]
        public async Task<IActionResult> Added(CreateCourseCategoryDto courseCategoryDto)
        {
            var value = _mapper.Map<CoursCategory>(courseCategoryDto);
            await _coursCategoryService.TAddAsync(value);
            if (value != null)
                return Ok(value);
            throw new Exception(Messages.NoSuccess);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Updated(UpdateCourseCategoryDto courseCategoryDto)
        {
            var value = _mapper.Map<CoursCategory>(courseCategoryDto);
            await _coursCategoryService.TUpdateAsync(value);
            if (value != null)
                return Ok(value);
            throw new Exception(Messages.NoSuccess);
        }
        [HttpDelete("deleted")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _coursCategoryService.TDeleteAsync(id);
            return Ok(Messages.IsSuccess);
        }
    }
}
