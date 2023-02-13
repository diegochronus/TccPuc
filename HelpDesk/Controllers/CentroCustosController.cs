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
    public class CentroCustosController : Controller
    {
        private readonly HelpDeskContext _context;

        public CentroCustosController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: CentroCustos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CentroCusto.ToListAsync());
        }

        // GET: CentroCustos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroCusto = await _context.CentroCusto
                .FirstOrDefaultAsync(m => m.idCentroCusto == id);
            if (centroCusto == null)
            {
                return NotFound();
            }

            return View(centroCusto);
        }

        // GET: CentroCustos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CentroCustos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCentroCusto,nmCentroCusto")] CentroCusto centroCusto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centroCusto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(centroCusto);
        }

        // GET: CentroCustos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroCusto = await _context.CentroCusto.FindAsync(id);
            if (centroCusto == null)
            {
                return NotFound();
            }
            return View(centroCusto);
        }

        // POST: CentroCustos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCentroCusto,nmCentroCusto")] CentroCusto centroCusto)
        {
            if (id != centroCusto.idCentroCusto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centroCusto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentroCustoExists(centroCusto.idCentroCusto))
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
            return View(centroCusto);
        }

        // GET: CentroCustos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroCusto = await _context.CentroCusto
                .FirstOrDefaultAsync(m => m.idCentroCusto == id);
            if (centroCusto == null)
            {
                return NotFound();
            }

            return View(centroCusto);
        }

        // POST: CentroCustos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centroCusto = await _context.CentroCusto.FindAsync(id);
            _context.CentroCusto.Remove(centroCusto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentroCustoExists(int id)
        {
            return _context.CentroCusto.Any(e => e.idCentroCusto == id);
        }
    }
}
