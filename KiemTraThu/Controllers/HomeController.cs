using System.Diagnostics;
using KiemTraThu.Data;
using KiemTraThu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemTraThu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QlhangHoaContext _context;

        public HomeController(ILogger<HomeController> logger, QlhangHoaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? maLoaiHang, decimal? gia)
        {
            var loaiHangHoas = _context.LoaiHangs.Include(c => c.HangHoas).ToList();

            if(maLoaiHang != null)
            {
                loaiHangHoas = loaiHangHoas.Where(c => c.MaLoai == maLoaiHang.Value).ToList();
            }

            if(gia != null)
            {
                // Lọc từng danh sách HangHoas theo giá
                foreach (var loai in loaiHangHoas)
                {
                    loai.HangHoas = loai.HangHoas
                        .Where(h => h.Gia > gia.Value)
                        .ToList();
                }
            }

            return View(loaiHangHoas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
