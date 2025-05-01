using AutoMapper;
using EDU.Business.Abstract;
using EDU.Business.Contect;
using EDU.DTO.DTOs.TestimonialDtos;
using EDU.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDU.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IGenericService<Testimonial> _testimonialService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _testimonialService.TGetAllAsync();
            if (values.Count > 0)
                return Ok(values);
            return Ok(Messages.NotData);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _testimonialService.TGetByIdAsync(id);
            if (value != null)
                return Ok(value);
            return Ok(Messages.NotData);
        }
        [HttpPost("added")]
        public async Task<IActionResult> Added(CreateTestimonialDto testimonialDto)
        {
            var value = _mapper.Map<Testimonial>(testimonialDto);
            await _testimonialService.TAddAsync(value);
            if (value != null)
                return Ok(Messages.IsSuccess);
            return Ok(Messages.NoSuccess);
        }
        [HttpPut("updated")]
        public async Task<IActionResult> Updated(UpdateTestimonialDto testimonialDto)
        {
            var value = _mapper.Map<Testimonial>(testimonialDto);
            await _testimonialService.TUpdateAsync(value);
            if (value != null)
                return Ok(Messages.IsSuccess);
            return Ok(Messages.NoSuccess);
        }
        [HttpDelete("deleted")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _testimonialService.TDeleteAsync(id);
            return Ok(Messages.IsSuccess);
        }
    }
}
