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
    public class JogoArbitrosController : Controller
    {
        private readonly CampeonatoContext _context;

        public JogoArbitrosController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: JogoArbitros
        public async Task<IActionResult> Index()
        {
            var campeonatoContext = _context.JogoArbitro.Include(j => j.IdArbitroNavigation).Include(j => j.IdJogoNavigation);
            return View(await campeonatoContext.ToListAsync());
        }

        // GET: JogoArbitros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoArbitro = await _context.JogoArbitro
                .Include(j => j.IdArbitroNavigation)
                .Include(j => j.IdJogoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogoArbitro == null)
            {
                return NotFound();
            }

            return View(jogoArbitro);
        }

        // GET: JogoArbitros/Create
        public IActionResult Create()
        {
            ViewData["IdArbitro"] = new SelectList(_context.Arbitro, "Id", "Nome");
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id");
            return View();
        }

        // POST: JogoArbitros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdJogo,IdArbitro")] JogoArbitro jogoArbitro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogoArbitro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArbitro"] = new SelectList(_context.Arbitro, "Id", "Nome", jogoArbitro.IdArbitro);
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id", jogoArbitro.IdJogo);
            return View(jogoArbitro);
        }

        // GET: JogoArbitros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoArbitro = await _context.JogoArbitro.FindAsync(id);
            if (jogoArbitro == null)
            {
                return NotFound();
            }
            ViewData["IdArbitro"] = new SelectList(_context.Arbitro, "Id", "Nome", jogoArbitro.IdArbitro);
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id", jogoArbitro.IdJogo);
            return View(jogoArbitro);
        }

        // POST: JogoArbitros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdJogo,IdArbitro")] JogoArbitro jogoArbitro)
        {
            if (id != jogoArbitro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogoArbitro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoArbitroExists(jogoArbitro.Id))
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
            ViewData["IdArbitro"] = new SelectList(_context.Arbitro, "Id", "Nome", jogoArbitro.IdArbitro);
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id", jogoArbitro.IdJogo);
            return View(jogoArbitro);
        }

        // GET: JogoArbitros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoArbitro = await _context.JogoArbitro
                .Include(j => j.IdArbitroNavigation)
                .Include(j => j.IdJogoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogoArbitro == null)
            {
                return NotFound();
            }

            return View(jogoArbitro);
        }

        // POST: JogoArbitros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogoArbitro = await _context.JogoArbitro.FindAsync(id);
            _context.JogoArbitro.Remove(jogoArbitro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoArbitroExists(int id)
        {
            return _context.JogoArbitro.Any(e => e.Id == id);
        }
    }
}
