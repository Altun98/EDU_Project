
using EDU.WebUI.DTOs.AboutDtos;
using EDU.WebUI.Halpers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace EDU.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            if (values != null)
            {
                return View(values);
            }
            return View();

        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _client.DeleteAsync($"abouts/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _client.PostAsJsonAsync("abouts", createAboutDto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UpdateAbout(int id)
        {
            try
            {
                var values = await _client.GetFromJsonAsync<UpdateAboutDto>($"Abouts/{id}");
                if (values != null)
                {
                    return View(values);
                }
            }
            catch (Exception ex)
            {

                return View(ex.Message, ex.StackTrace);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _client.PutAsJsonAsync("abouts", updateAboutDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
