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
    public class EstadoChamadosController : Controller
    {
        private readonly HelpDeskContext _context;

        public EstadoChamadosController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: EstadoChamados
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoChamadocs.ToListAsync());
        }

        // GET: EstadoChamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoChamadocs = await _context.EstadoChamadocs
                .FirstOrDefaultAsync(m => m.idEstadoChamado == id);
            if (estadoChamadocs == null)
            {
                return NotFound();
            }

            return View(estadoChamadocs);
        }

        // GET: EstadoChamados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoChamados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idEstadoChamado,nmEstadoChamado")] EstadoChamadocs estadoChamadocs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoChamadocs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoChamadocs);
        }

        // GET: EstadoChamados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoChamadocs = await _context.EstadoChamadocs.FindAsync(id);
            if (estadoChamadocs == null)
            {
                return NotFound();
            }
            return View(estadoChamadocs);
        }

        // POST: EstadoChamados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idEstadoChamado,nmEstadoChamado")] EstadoChamadocs estadoChamadocs)
        {
            if (id != estadoChamadocs.idEstadoChamado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoChamadocs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoChamadocsExists(estadoChamadocs.idEstadoChamado))
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
            return View(estadoChamadocs);
        }

        // GET: EstadoChamados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoChamadocs = await _context.EstadoChamadocs
                .FirstOrDefaultAsync(m => m.idEstadoChamado == id);
            if (estadoChamadocs == null)
            {
                return NotFound();
            }

            return View(estadoChamadocs);
        }

        // POST: EstadoChamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoChamadocs = await _context.EstadoChamadocs.FindAsync(id);
            _context.EstadoChamadocs.Remove(estadoChamadocs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoChamadocsExists(int id)
        {
            return _context.EstadoChamadocs.Any(e => e.idEstadoChamado == id);
        }
    }
}
