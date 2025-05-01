using AutoMapper;
using EDU.Business.Abstract;
using EDU.Business.Contect;
using EDU.DTO.DTOs.CoursCategoryDtos;
using EDU.DTO.DTOs.CourseDtos;
using EDU.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(IGenericService<Course> _courseService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _courseService.TGetAllAsync();
            var result = _mapper.Map<List<ResultCoursDto>>(values);
            if (values.Count > 0)
                return Ok(values);
            return Ok(Messages.NotData);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _courseService.TGetByIdAsync(id);
            if (value != null)
                return Ok(value);
            return Ok(Messages.NotData);
        }
        [HttpPost("added")]
        public async Task<IActionResult> Added(CreateCoursDto createCours)
        {
            var value = _mapper.Map<Course>(createCours);
            await _courseService.TAddAsync(value);
            if (value != null)
                return Ok(value);
            throw new Exception(Messages.NoSuccess);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Updated(UpdateCoursDto updateCours)
        {
            var value = _mapper.Map<Course>(updateCours);
            await _courseService.TUpdateAsync(value);
            if (value != null)
                return Ok(value);
            throw new Exception(Messages.NoSuccess);
        }
        [HttpDelete("deleted")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _courseService.TDeleteAsync(id);
            return Ok(Messages.IsSuccess);
        }
    }
}
