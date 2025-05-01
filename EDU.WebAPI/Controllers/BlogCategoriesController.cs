using AutoMapper;
using EDU.Business.Abstract;
using EDU.Business.Contect;
using EDU.DTO.DTOs.BlogCategoryDtos;
using EDU.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController(IGenericService<BlogCategory> _blogCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> Getall()
        {
            var values = await _blogCategoryService.TGetAllAsync();
            if (values.Count > 0)
                return Ok(values);
            return BadRequest(Messages.NotData);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _blogCategoryService.TGetByIdAsync(id);
            if (value != null)
                return Ok(value);
            return BadRequest(Messages.NotData);
        }
        [HttpPost("added")]
        public async Task<IActionResult> Added(CreateBlogCategoryDto createBlog)
        {
            var value = _mapper.Map<BlogCategory>(createBlog);
            await _blogCategoryService.TAddAsync(value);
            if (value != null)
                return Ok(value);
            return BadRequest(Messages.NoSuccess);
        }
        [HttpPut("updated")]
        public async Task<IActionResult> Updated(UpdateBlogCategoryDto updateBlog)
        {
            var value = _mapper.Map<BlogCategory>(updateBlog);
            await _blogCategoryService.TUpdateAsync(value);
            if (value != null)
                return Ok(value);
            return BadRequest(Messages.NoSuccess);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _blogCategoryService.TDeleteAsync(id);
            return Ok(Messages.IsSuccess);
        }
    }
}
