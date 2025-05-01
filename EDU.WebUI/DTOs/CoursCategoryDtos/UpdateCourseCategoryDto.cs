using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.WebUI.DTOs.CoursCategoryDtos
{
    public class UpdateCourseCategoryDto
    {
        public int CoursCategoryId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsShown { get; set; }
    }
}
