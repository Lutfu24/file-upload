using FrontToBack.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SliderController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Slider> sliders = _context.Sliders.AsEnumerable();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(SliderViewModel sliderViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            if (sliderViewModel.Image is null) return Content("boshdur");

            string fileName = $"{Guid.NewGuid()}-{sliderViewModel.Image.FileName}";
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images", "website-images", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
               await  sliderViewModel.Image.CopyToAsync(stream);
            }

            Slider slider = new()
            {
                Title = sliderViewModel.Title,
                Offer = sliderViewModel.Offer,
                Image = fileName
            };

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}
