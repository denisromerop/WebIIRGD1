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
    public class ResultadosController : Controller
    {
        private readonly CampeonatoContext _context;

        public ResultadosController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: Resultados
        public async Task<IActionResult> Index()
        {
            var campeonatoContext = _context.Resultado.Include(r => r.IdJogoNavigation).Include(r => r.IdTimeNavigation);
            return View(await campeonatoContext.ToListAsync());
        }

        // GET: Resultados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultado
                .Include(r => r.IdJogoNavigation)
                .Include(r => r.IdTimeNavigation)
                .FirstOrDefaultAsync(m => m.id == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // GET: Resultados/Create
        public IActionResult Create()
        {
            ViewData["idjogo"] = new SelectList(_context.Jogo, "Id", "Id");
            ViewData["idTime"] = new SelectList(_context.Time, "Id", "Nome");
            return View();
        }

        // POST: Resultados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,idjogo,idTime,Vitorias,empates,derrotas,golsPro,golsContra,saldodeGol,qtdjogos,PontosGanhos")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idjogo"] = new SelectList(_context.Jogo, "Id", "Id", resultado.idjogo);
            ViewData["idTime"] = new SelectList(_context.Time, "Id", "Nome", resultado.idTime);
            return View(resultado);
        }

        // GET: Resultados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultado.FindAsync(id);
            if (resultado == null)
            {
                return NotFound();
            }
            ViewData["idjogo"] = new SelectList(_context.Jogo, "Id", "Id", resultado.idjogo);
            ViewData["idTime"] = new SelectList(_context.Time, "Id", "Nome", resultado.idTime);
            return View(resultado);
        }

        // POST: Resultados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,idjogo,idTime,Vitorias,empates,derrotas,golsPro,golsContra,saldodeGol,qtdjogos,PontosGanhos")] Resultado resultado)
        {
            if (id != resultado.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultadoExists(resultado.id))
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
            ViewData["idjogo"] = new SelectList(_context.Jogo, "Id", "Id", resultado.idjogo);
            ViewData["idTime"] = new SelectList(_context.Time, "Id", "Nome", resultado.idTime);
            return View(resultado);
        }

        // GET: Resultados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultado
                .Include(r => r.IdJogoNavigation)
                .Include(r => r.IdTimeNavigation)
                .FirstOrDefaultAsync(m => m.id == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // POST: Resultados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultado = await _context.Resultado.FindAsync(id);
            _context.Resultado.Remove(resultado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultadoExists(int id)
        {
            return _context.Resultado.Any(e => e.id == id);
        }
    }
}
