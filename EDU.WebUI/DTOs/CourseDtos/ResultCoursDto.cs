
using EDU.WebUI.DTOs.CoursCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.WebUI.DTOs.CourseDtos
{
    public class ResultCoursDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public ResultCoursCategoryDto Category { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
    }
}
