using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCampeonato;
using WebCampeonato.Models;

namespace WebCampeonato.Controllers
{
    public class ArbitrosController : Controller
    {
        private readonly CampeonatoContext _context;

        public ArbitrosController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: Arbitros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arbitro.ToListAsync());
        }

        // GET: Arbitros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arbitro = await _context.Arbitro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arbitro == null)
            {
                return NotFound();
            }

            return View(arbitro);
        }

        // GET: Arbitros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arbitros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Posicao,Fifa,Federacao,Foto")] Arbitro arbitro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arbitro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arbitro);
        }

        // GET: Arbitros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arbitro = await _context.Arbitro.FindAsync(id);
            if (arbitro == null)
            {
                return NotFound();
            }
            return View(arbitro);
        }

        // POST: Arbitros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Posicao,Fifa,Federacao,Foto")] Arbitro arbitro)
        {
            if (id != arbitro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arbitro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArbitroExists(arbitro.Id))
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
            return View(arbitro);
        }

        // GET: Arbitros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arbitro = await _context.Arbitro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arbitro == null)
            {
                return NotFound();
            }

            return View(arbitro);
        }

        // POST: Arbitros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arbitro = await _context.Arbitro.FindAsync(id);
            _context.Arbitro.Remove(arbitro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArbitroExists(int id)
        {
            return _context.Arbitro.Any(e => e.Id == id);
        }
    }
}
