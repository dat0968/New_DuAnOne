using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Du_An_One.Data;
using Du_An_One.Models;

namespace Du_An_One.Controllers
{
    public class SANPHAMsController : Controller
    {
        private readonly Du_An_OneContext _context;

        public SANPHAMsController(Du_An_OneContext context)
        {
            _context = context;
        }

        // GET: SANPHAMs
        public async Task<IActionResult> Index()
        {
              return _context.SANPHAM != null ? 
                          View(await _context.SANPHAM.ToListAsync()) :
                          Problem("Entity set 'Du_An_OneContext.SANPHAM'  is null.");
        }

        // GET: SANPHAMs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SANPHAM == null)
            {
                return NotFound();
            }

            var sANPHAM = await _context.SANPHAM
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sANPHAM == null)
            {
                return NotFound();
            }

            return View(sANPHAM);
        }

        // GET: SANPHAMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSP,TenSP,SoLuongBan,DonGiaBan,NgayNhap,DanhMucHang,KichCo,MoTa,MaKhuyenMai,MaNV")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sANPHAM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SANPHAM == null)
            {
                return NotFound();
            }

            var sANPHAM = await _context.SANPHAM.FindAsync(id);
            if (sANPHAM == null)
            {
                return NotFound();
            }
            return View(sANPHAM);
        }

        // POST: SANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSP,TenSP,SoLuongBan,DonGiaBan,NgayNhap,DanhMucHang,KichCo,MoTa,MaKhuyenMai,MaNV")] SANPHAM sANPHAM)
        {
            if (id != sANPHAM.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sANPHAM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SANPHAMExists(sANPHAM.MaSP))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SANPHAM == null)
            {
                return NotFound();
            }

            var sANPHAM = await _context.SANPHAM
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sANPHAM == null)
            {
                return NotFound();
            }

            return View(sANPHAM);
        }

        // POST: SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SANPHAM == null)
            {
                return Problem("Entity set 'Du_An_OneContext.SANPHAM'  is null.");
            }
            var sANPHAM = await _context.SANPHAM.FindAsync(id);
            if (sANPHAM != null)
            {
                _context.SANPHAM.Remove(sANPHAM);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SANPHAMExists(string id)
        {
          return (_context.SANPHAM?.Any(e => e.MaSP == id)).GetValueOrDefault();
        }
    }
}
