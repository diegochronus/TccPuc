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
    public class TiposController : Controller
    {
        private readonly HelpDeskContext _context;

        public TiposController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: Tipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipo.ToListAsync());
        }

        // GET: Tipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipo
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // GET: Tipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipo,NmTipo")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo);
        }

        // GET: Tipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipo.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return View(tipo);
        }

        // POST: Tipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipo,NmTipo")] Tipo tipo)
        {
            if (id != tipo.IdTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoExists(tipo.IdTipo))
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
            return View(tipo);
        }

        // GET: Tipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipo
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // POST: Tipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipo = await _context.Tipo.FindAsync(id);
            _context.Tipo.Remove(tipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoExists(int id)
        {
            return _context.Tipo.Any(e => e.IdTipo == id);
        }
    }
}
