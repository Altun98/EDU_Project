using EDU.DTO.DTOs.BlogDtos;
using EDU.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.DTO.DTOs.BlogCategoryDtos
{
    public class ResultBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<ResultBlogDto> Blogs { get; set; }
    }
}
