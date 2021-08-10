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
    public class TimeJogosController : Controller
    {
        private readonly CampeonatoContext _context;

        public TimeJogosController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: TimeJogos
        public async Task<IActionResult> Index()
        {
            var campeonatoContext = _context.TimeJogo.Include(t => t.IdJogoNavigation).Include(t => t.IdTimeNavigation);
            return View(await campeonatoContext.ToListAsync());
        }

        // GET: TimeJogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeJogo = await _context.TimeJogo
                .Include(t => t.IdJogoNavigation)
                .Include(t => t.IdTimeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeJogo == null)
            {
                return NotFound();
            }

            return View(timeJogo);
        }

        // GET: TimeJogos/Create
        public IActionResult Create()
        {
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id");
            ViewData["IdTime"] = new SelectList(_context.Time, "Id", "Nome");
            return View();
        }

        // POST: TimeJogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTime,IdJogo,Gols")] TimeJogo timeJogo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeJogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id", timeJogo.IdJogo);
            ViewData["IdTime"] = new SelectList(_context.Time, "Id", "Nome", timeJogo.IdTime);
            return View(timeJogo);
        }

        // GET: TimeJogos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeJogo = await _context.TimeJogo.FindAsync(id);
            if (timeJogo == null)
            {
                return NotFound();
            }
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id", timeJogo.IdJogo);
            ViewData["IdTime"] = new SelectList(_context.Time, "Id", "Nome", timeJogo.IdTime);
            return View(timeJogo);
        }

        // POST: TimeJogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTime,IdJogo,Gols")] TimeJogo timeJogo)
        {
            if (id != timeJogo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeJogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeJogoExists(timeJogo.Id))
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
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id", timeJogo.IdJogo);
            ViewData["IdTime"] = new SelectList(_context.Time, "Id", "Nome", timeJogo.IdTime);
            return View(timeJogo);
        }

        // GET: TimeJogos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeJogo = await _context.TimeJogo
                .Include(t => t.IdJogoNavigation)
                .Include(t => t.IdTimeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeJogo == null)
            {
                return NotFound();
            }

            return View(timeJogo);
        }

        // POST: TimeJogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeJogo = await _context.TimeJogo.FindAsync(id);
            _context.TimeJogo.Remove(timeJogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeJogoExists(int id)
        {
            return _context.TimeJogo.Any(e => e.Id == id);
        }
    }
}
