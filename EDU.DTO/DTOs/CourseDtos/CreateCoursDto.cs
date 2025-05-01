using EDU.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.DTO.DTOs.CourseDtos
{
    public class CreateCoursDto
    {
        public string CourseName { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
    }
}
