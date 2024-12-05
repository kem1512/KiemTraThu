using KiemTraThu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemTraThu.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _context;

        public RenderViewComponent(QlhangHoaContext context)
        {
            _context = context;    
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderMenu", await _context.LoaiHangs.ToListAsync());
        }
    }
}
