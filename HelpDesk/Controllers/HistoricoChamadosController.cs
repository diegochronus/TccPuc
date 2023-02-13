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
    public class HistoricoChamadosController : Controller
    {
        private readonly HelpDeskContext _context;

        public HistoricoChamadosController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: HistoricoChamados
        public async Task<IActionResult> Index()
        {
            return View(await _context.HistoricoChamado.ToListAsync());
        }

        // GET: HistoricoChamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoChamado = await _context.HistoricoChamado
                .FirstOrDefaultAsync(m => m.IdHistorico == id);
            if (historicoChamado == null)
            {
                return NotFound();
            }

            return View(historicoChamado);
        }

        // GET: HistoricoChamados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HistoricoChamados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHistorico,DescHistorico,DataHistorico,IdChamado,IdUsuario")] HistoricoChamado historicoChamado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historicoChamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historicoChamado);
        }

        // GET: HistoricoChamados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoChamado = await _context.HistoricoChamado.FindAsync(id);
            if (historicoChamado == null)
            {
                return NotFound();
            }
            return View(historicoChamado);
        }

        // POST: HistoricoChamados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHistorico,DescHistorico,DataHistorico,IdChamado,IdUsuario")] HistoricoChamado historicoChamado)
        {
            if (id != historicoChamado.IdHistorico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicoChamado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoChamadoExists(historicoChamado.IdHistorico))
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
            return View(historicoChamado);
        }

        // GET: HistoricoChamados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoChamado = await _context.HistoricoChamado
                .FirstOrDefaultAsync(m => m.IdHistorico == id);
            if (historicoChamado == null)
            {
                return NotFound();
            }

            return View(historicoChamado);
        }

        // POST: HistoricoChamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historicoChamado = await _context.HistoricoChamado.FindAsync(id);
            _context.HistoricoChamado.Remove(historicoChamado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoChamadoExists(int id)
        {
            return _context.HistoricoChamado.Any(e => e.IdHistorico == id);
        }
    }
}
