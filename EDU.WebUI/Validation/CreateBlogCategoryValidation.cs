using EDU.WebUI.DTOs.BlogCategoryDtos;
using FluentValidation;

namespace EDU.WebUI.Validation
{
    public class CreateBlogCategoryValidation:AbstractValidator<CreateBlogCategoryDto>
    {
        public CreateBlogCategoryValidation()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("adi bos saxlana bilmez");
        }
    }
}
