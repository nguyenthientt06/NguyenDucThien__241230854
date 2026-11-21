using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenDucThien__241230854.Models;

namespace NguyenDucThien__241230854.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext _context;

        public HomeController(QlhangHoaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TieuDe = "Nguyễn Đức Thiện";
            var dsHangHoa = await _context.HangHoas
                .Where(h => h.Gia != null && h.Gia >= 100)
                .ToListAsync();
            return View(dsHangHoa);
        }

        [HttpGet]
        public async Task<IActionResult> LocTheoLoai(int? maLoai)
        {
            if (maLoai.HasValue && maLoai.Value > 0)
            {
                var loai = await _context.LoaiHangs.FindAsync(maLoai.Value);
                ViewBag.TieuDe = loai?.TenLoai ?? "Nguyễn Đức Thiện";

                var dsTheoLoai = await _context.HangHoas
                    .Where(h => h.MaLoai == maLoai.Value)
                    .ToListAsync();
                return PartialView("_HangHoaListPartial", dsTheoLoai);
            }

            ViewBag.TieuDe = "Nguyễn Đức Thiện";
            var dsMacDinh = await _context.HangHoas
                .Where(h => h.Gia != null && h.Gia >= 100)
                .ToListAsync();
            return PartialView("_HangHoaListPartial", dsMacDinh);
        }
    }
}