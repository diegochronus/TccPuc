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
    public class SetoresController : Controller
    {
        private readonly HelpDeskContext _context;

        public SetoresController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: Setores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Setores.ToListAsync());
        }

        // GET: Setores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setores = await _context.Setores
                .FirstOrDefaultAsync(m => m.IdSetor == id);
            if (setores == null)
            {
                return NotFound();
            }

            return View(setores);
        }

        // GET: Setores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Setores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSetor,NmSetor")] Setores setores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(setores);
        }

        // GET: Setores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setores = await _context.Setores.FindAsync(id);
            if (setores == null)
            {
                return NotFound();
            }
            return View(setores);
        }

        // POST: Setores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSetor,NmSetor")] Setores setores)
        {
            if (id != setores.IdSetor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(setores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetoresExists(setores.IdSetor))
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
            return View(setores);
        }

        // GET: Setores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setores = await _context.Setores
                .FirstOrDefaultAsync(m => m.IdSetor == id);
            if (setores == null)
            {
                return NotFound();
            }

            return View(setores);
        }

        // POST: Setores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var setores = await _context.Setores.FindAsync(id);
            _context.Setores.Remove(setores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetoresExists(int id)
        {
            return _context.Setores.Any(e => e.IdSetor == id);
        }
    }
}
