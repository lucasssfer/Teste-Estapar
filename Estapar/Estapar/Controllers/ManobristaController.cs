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
    public class ManobristaController : Controller
    {
        private readonly EstaparContext _context;

        public ManobristaController(EstaparContext context)
        {
            _context = context;
        }

        // GET: Manobrista
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manobrista.ToListAsync());
        }

        // GET: Manobrista/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobrista = await _context.Manobrista
                .FirstOrDefaultAsync(m => m.ManobristaId == id);
            if (manobrista == null)
            {
                return NotFound();
            }

            return View(manobrista);
        }

        // GET: Manobrista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manobrista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManobristaId,Name,Cpf,DataNascimento")] Manobrista manobrista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manobrista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manobrista);
        }

        // GET: Manobrista/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobrista = await _context.Manobrista.FindAsync(id);
            if (manobrista == null)
            {
                return NotFound();
            }
            return View(manobrista);
        }

        // POST: Manobrista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ManobristaId,Name,Cpf,DataNascimento")] Manobrista manobrista)
        {
            if (id != manobrista.ManobristaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manobrista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManobristaExists(manobrista.ManobristaId))
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
            return View(manobrista);
        }

        // GET: Manobrista/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobrista = await _context.Manobrista
                .FirstOrDefaultAsync(m => m.ManobristaId == id);
            if (manobrista == null)
            {
                return NotFound();
            }

            return View(manobrista);
        }

        // POST: Manobrista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var manobrista = await _context.Manobrista.FindAsync(id);
            _context.Manobrista.Remove(manobrista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManobristaExists(long id)
        {
            return _context.Manobrista.Any(e => e.ManobristaId == id);
        }
    }
}
