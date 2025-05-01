using EDU.WebUI.DTOs.BlogCategoryDtos;
using EDU.WebUI.Halpers;
using EDU.WebUI.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDU.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("BlogCategories/getall");
            return View(values);
        }
        public async Task<IActionResult> DeleteBlogCategory(int id)
        {
            await _client.DeleteAsync($"BlogCategories/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateBlogCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var validation = new CreateBlogCategoryValidation();
            var result = await validation.ValidateAsync(createBlogCategoryDto);
            if (!result.IsValid)
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
                return View(result);
            }

            await _client.PostAsJsonAsync("BlogCategories/added", createBlogCategoryDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateBlogCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateBlogCategoryDto>($"BlogCategories/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            await _client.PutAsJsonAsync("BlogCategories/updated", updateBlogCategoryDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
