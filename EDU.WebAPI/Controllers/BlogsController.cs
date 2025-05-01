using AutoMapper;
using EDU.Business.Abstract;
using EDU.Business.Contect;
using EDU.DTO.DTOs.BlogDtos;
using EDU.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IGenericService<Blog> _blogService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _blogService.TGetAllAsync();
            if (values.Count > 0)
                return Ok(values);
            return BadRequest(Messages.NotData);
        }
        private IActionResult OperationControllerMessageShow(object value)
        {
            if (value != null)
                return Ok(Messages.IsSuccess);
            return BadRequest(Messages.NoSuccess);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _blogService.TGetByIdAsync(id);
            if (value != null)
                return Ok(Messages.IsSuccess);
            return BadRequest(Messages.NotData);
        }
        [HttpPost("added")]
        public async Task<IActionResult> Added(CreateBlogDto createBlog)
        {
            var value = _mapper.Map<Blog>(createBlog);
            await _blogService.TAddAsync(value);
            return OperationControllerMessageShow(value);
        }
        [HttpPut("updated")]
        public async Task<IActionResult> Updated(UpdateBlogDto updateBlog)
        {
            var value = _mapper.Map<Blog>(updateBlog);
            await _blogService.TUpdateAsync(value);
            return OperationControllerMessageShow(value);
        }
        [HttpDelete("deleted")]
        public async Task<IActionResult> Deleted(int id)
        {
            try
            {
                await _blogService.TDeleteAsync(id);
                return Ok(Messages.IsSuccess);
            }
            catch (Exception)
            {
                return BadRequest(Messages.NoSuccess);
            }
        }
    }
}
