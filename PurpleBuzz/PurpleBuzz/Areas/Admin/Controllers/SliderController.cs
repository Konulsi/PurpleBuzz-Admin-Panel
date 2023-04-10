using FrontToBack.Data;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {

        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<SliderImage> slider = await _context.SliderImages.Where(m => !m.SoftDelete).ToListAsync();
            return View(slider);
        }
        public async Task<IActionResult> Detail(int? id)
        {

            if (id == null) return BadRequest();
            SliderImage slider = await _context.SliderImages.FirstOrDefaultAsync(m => m.Id == id);


            if (slider == null) return NotFound();
            return View(slider);
        }


        [HttpGet]

        public IActionResult Create()
        {

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();
            SliderImage slider = await _context.SliderImages.FirstOrDefaultAsync(m => m.Id == id);

            if (slider == null) return NotFound();
            return View(slider);

        }
    }
}
