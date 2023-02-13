using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class NivelOperacionalController : Controller
    {
        private readonly HelpDeskContext _context;

        public NivelOperacionalController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: NivelOperacional
        public async Task<IActionResult> Index()
        {
            return View(await _context.NivelOperacional.ToListAsync());
        }

        // GET: NivelOperacional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelOperacional = await _context.NivelOperacional
                .FirstOrDefaultAsync(m => m.IdNivelOperacional == id);
            if (nivelOperacional == null)
            {
                return NotFound();
            }

            return View(nivelOperacional);
        }

        // GET: NivelOperacional/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelOperacional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNivelOperacional,NmNivelOperacional")] NivelOperacional nivelOperacional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelOperacional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelOperacional);
        }

        // GET: NivelOperacional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelOperacional = await _context.NivelOperacional.FindAsync(id);
            if (nivelOperacional == null)
            {
                return NotFound();
            }
            return View(nivelOperacional);
        }

        // POST: NivelOperacional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNivelOperacional,NmNivelOperacional")] NivelOperacional nivelOperacional)
        {
            if (id != nivelOperacional.IdNivelOperacional)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelOperacional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelOperacionalExists(nivelOperacional.IdNivelOperacional))
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
            return View(nivelOperacional);
        }

        // GET: NivelOperacional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelOperacional = await _context.NivelOperacional
                .FirstOrDefaultAsync(m => m.IdNivelOperacional == id);
            if (nivelOperacional == null)
            {
                return NotFound();
            }

            return View(nivelOperacional);
        }

        // POST: NivelOperacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nivelOperacional = await _context.NivelOperacional.FindAsync(id);
            _context.NivelOperacional.Remove(nivelOperacional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelOperacionalExists(int id)
        {
            return _context.NivelOperacional.Any(e => e.IdNivelOperacional == id);
        }
    }
}
