using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cinisatissitesi.Data;
using cinisatissitesi.Models;

namespace cinisatissitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ANA SAYFA - ürünleri gösterir
        public async Task<IActionResult> Index()
        {
            var urunler = await _context.Ciniler.ToListAsync();
            return View(urunler);
        }

        // HAKKINDA SAYFASI
        public IActionResult Privacy()
        {
            return View();
        }

        // HATA SAYFASI
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}