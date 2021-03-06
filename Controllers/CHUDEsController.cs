using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shophoatuoi.Models;

namespace shophoatuoi.Controllers
{
    public class ChudesController : Controller
    {
        private readonly acomptec_shophoaContext _context = new acomptec_shophoaContext();

        // GET: Chudes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chude.ToListAsync());
        }
        

        // GET: Chudes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chude = await _context.Chude
                .FirstOrDefaultAsync(m => m.CdMa == id);
            if (chude == null)
            {
                return NotFound();
            }

            return View(chude);
        }

        // GET: Chudes/Create
        public IActionResult Create()
        {
            int MIN = 0001;
            int MAX = 9999;
            Random RD = new Random();
            Chude obj = new Chude();
            obj.CdMa = RD.Next(MIN, MAX).ToString();
            return View(obj);
        }

        // POST: Chudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdMa,CdTen")] Chude chude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chude);
        }

        // GET: Chudes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chude = await _context.Chude.FindAsync(id);
            if (chude == null)
            {
                return NotFound();
            }
            return View(chude);
        }

        // POST: Chudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CdMa,CdTen")] Chude chude)
        {
            if (id != chude.CdMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChudeExists(chude.CdMa))
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
            return View(chude);
        }

        // GET: Chudes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chude = await _context.Chude
                .FirstOrDefaultAsync(m => m.CdMa == id);
            if (chude == null)
            {
                return NotFound();
            }

            return View(chude);
        }

        // POST: Chudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chude = await _context.Chude.FindAsync(id);
            _context.Chude.Remove(chude);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChudeExists(string id)
        {
            return _context.Chude.Any(e => e.CdMa == id);
        }
    }
}
