using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estapar.Models;

namespace Estapar.Controllers
{
    public class ManobraController : Controller
    {
        private readonly EstaparContext _context;

        public ManobraController(EstaparContext context)
        {
            _context = context;
        }

        // GET: Manobra
        public async Task<IActionResult> Index()
        {
            var estaparContext = _context.Manobra.Include(m => m.Manobrista).Include(m => m.Veiculo);
            return View(await estaparContext.ToListAsync());
        }

        // GET: Manobra/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobra = await _context.Manobra
                .Include(m => m.Manobrista)
                .Include(m => m.Veiculo)
                .FirstOrDefaultAsync(m => m.ManobraId == id);
            if (manobra == null)
            {
                return NotFound();
            }

            return View(manobra);
        }

        // GET: Manobra/Create
        public IActionResult Create()
        {
            ViewData["ManobristaId"] = new SelectList(_context.Manobrista, "ManobristaId", "Cpf");
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "VeiculoId", "Marca");
            return View();
        }

        // POST: Manobra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManobraId,ManobristaId,VeiculoId,DataManobra")] Manobra manobra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manobra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManobristaId"] = new SelectList(_context.Manobrista, "ManobristaId", "Cpf", manobra.ManobristaId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "VeiculoId", "Marca", manobra.VeiculoId);
            return View(manobra);
        }

        // GET: Manobra/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobra = await _context.Manobra.FindAsync(id);
            if (manobra == null)
            {
                return NotFound();
            }
            ViewData["ManobristaId"] = new SelectList(_context.Manobrista, "ManobristaId", "Cpf", manobra.ManobristaId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "VeiculoId", "Marca", manobra.VeiculoId);
            return View(manobra);
        }

        // POST: Manobra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ManobraId,ManobristaId,VeiculoId,DataManobra")] Manobra manobra)
        {
            if (id != manobra.ManobraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manobra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManobraExists(manobra.ManobraId))
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
            ViewData["ManobristaId"] = new SelectList(_context.Manobrista, "ManobristaId", "Cpf", manobra.ManobristaId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "VeiculoId", "Marca", manobra.VeiculoId);
            return View(manobra);
        }

        // GET: Manobra/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobra = await _context.Manobra
                .Include(m => m.Manobrista)
                .Include(m => m.Veiculo)
                .FirstOrDefaultAsync(m => m.ManobraId == id);
            if (manobra == null)
            {
                return NotFound();
            }

            return View(manobra);
        }

        // POST: Manobra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var manobra = await _context.Manobra.FindAsync(id);
            _context.Manobra.Remove(manobra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManobraExists(long id)
        {
            return _context.Manobra.Any(e => e.ManobraId == id);
        }
    }
}
