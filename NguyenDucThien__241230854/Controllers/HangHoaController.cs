using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenDucThien__241230854.Models;

namespace NguyenDucThien__241230854.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly QlhangHoaContext _context;

        public HangHoaController(QlhangHoaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenHang,Gia,Anh")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                hangHoa.TenHang = hangHoa.TenHang.Trim();
                hangHoa.Anh = hangHoa.Anh?.Trim();

                _context.HangHoas.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }
    }
}