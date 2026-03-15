using cinisatissitesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cinisatissitesi.Controllers
{
    public class UrunController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UrunController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Detay(int id)
        {
            var urun = await _context.Ciniler.FirstOrDefaultAsync(x => x.Id == id);

            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }
    }
}