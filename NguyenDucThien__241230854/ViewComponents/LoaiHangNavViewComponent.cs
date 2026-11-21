using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenDucThien__241230854.Models;

namespace NguyenDucThien__241230854.ViewComponents
{
    public class LoaiHangNavViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _context;

        public LoaiHangNavViewComponent(QlhangHoaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiHangs = await _context.LoaiHangs.ToListAsync();
            return View(loaiHangs);
        }
    }
}