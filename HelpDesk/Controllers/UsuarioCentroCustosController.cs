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
    public class UsuarioCentroCustosController : Controller
    {
        private readonly HelpDeskContext _context;

        public UsuarioCentroCustosController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: UsuarioCentroCustos
        public async Task<IActionResult> Index()
        {
            return View(await _context.usuarioCentroCusto.ToListAsync());
        }

        // GET: UsuarioCentroCustos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioCentroCusto = await _context.usuarioCentroCusto
                .FirstOrDefaultAsync(m => m.idUsuario == id);
            if (usuarioCentroCusto == null)
            {
                return NotFound();
            }

            return View(usuarioCentroCusto);
        }

        // GET: UsuarioCentroCustos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioCentroCustos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idUsuario,idCentroCusto")] usuarioCentroCusto usuarioCentroCusto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioCentroCusto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioCentroCusto);
        }

        // GET: UsuarioCentroCustos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioCentroCusto = await _context.usuarioCentroCusto.FindAsync(id);
            if (usuarioCentroCusto == null)
            {
                return NotFound();
            }
            return View(usuarioCentroCusto);
        }

        // POST: UsuarioCentroCustos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idUsuario,idCentroCusto")] usuarioCentroCusto usuarioCentroCusto)
        {
            if (id != usuarioCentroCusto.idUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioCentroCusto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!usuarioCentroCustoExists(usuarioCentroCusto.idUsuario))
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
            return View(usuarioCentroCusto);
        }

        // GET: UsuarioCentroCustos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioCentroCusto = await _context.usuarioCentroCusto
                .FirstOrDefaultAsync(m => m.idUsuario == id);
            if (usuarioCentroCusto == null)
            {
                return NotFound();
            }

            return View(usuarioCentroCusto);
        }

        // POST: UsuarioCentroCustos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioCentroCusto = await _context.usuarioCentroCusto.FindAsync(id);
            _context.usuarioCentroCusto.Remove(usuarioCentroCusto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool usuarioCentroCustoExists(int id)
        {
            return _context.usuarioCentroCusto.Any(e => e.idUsuario == id);
        }
    }
}
