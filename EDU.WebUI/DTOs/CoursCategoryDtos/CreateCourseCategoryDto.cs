using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.WebUI.DTOs.CoursCategoryDtos
{
    public class CreateCourseCategoryDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsShown { get; set; }
    }
}
