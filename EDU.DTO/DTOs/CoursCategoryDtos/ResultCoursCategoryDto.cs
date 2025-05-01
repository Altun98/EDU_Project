using EDU.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.DTO.DTOs.CoursCategoryDtos
{
    public class ResultCoursCategoryDto
    {
        public int CoursCategoryId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsShown { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
