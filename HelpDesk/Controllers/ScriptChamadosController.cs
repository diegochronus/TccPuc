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
    public class ScriptChamadosController : Controller
    {
        private readonly HelpDeskContext _context;

        public ScriptChamadosController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: ScriptChamados
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScriptChamado.ToListAsync());
        }

        // GET: ScriptChamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scriptChamado = await _context.ScriptChamado
                .FirstOrDefaultAsync(m => m.IdScriptChamado == id);
            if (scriptChamado == null)
            {
                return NotFound();
            }

            return View(scriptChamado);
        }

        // GET: ScriptChamados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScriptChamados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdScriptChamado,DesScript,IdSubGategoria")] ScriptChamado scriptChamado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scriptChamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scriptChamado);
        }

        // GET: ScriptChamados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scriptChamado = await _context.ScriptChamado.FindAsync(id);
            if (scriptChamado == null)
            {
                return NotFound();
            }
            return View(scriptChamado);
        }

        // POST: ScriptChamados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdScriptChamado,DesScript,IdSubGategoria")] ScriptChamado scriptChamado)
        {
            if (id != scriptChamado.IdScriptChamado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scriptChamado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScriptChamadoExists(scriptChamado.IdScriptChamado))
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
            return View(scriptChamado);
        }

        // GET: ScriptChamados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scriptChamado = await _context.ScriptChamado
                .FirstOrDefaultAsync(m => m.IdScriptChamado == id);
            if (scriptChamado == null)
            {
                return NotFound();
            }

            return View(scriptChamado);
        }

        // POST: ScriptChamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scriptChamado = await _context.ScriptChamado.FindAsync(id);
            _context.ScriptChamado.Remove(scriptChamado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScriptChamadoExists(int id)
        {
            return _context.ScriptChamado.Any(e => e.IdScriptChamado == id);
        }
    }
}
