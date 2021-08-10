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
    public class JogoJogadorCartaosController : Controller
    {
        private readonly CampeonatoContext _context;

        public JogoJogadorCartaosController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: JogoJogadorCartaos
        public async Task<IActionResult> Index()
        {
            var campeonatoContext = _context.JogoJogadorCartao.Include(j => j.IdCartaoNavigation).Include(j => j.IdJogadorNavigation).Include(j => j.IdJogoNavigation);
            return View(await campeonatoContext.ToListAsync());
        }

        // GET: JogoJogadorCartaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoJogadorCartao = await _context.JogoJogadorCartao
                .Include(j => j.IdCartaoNavigation)
                .Include(j => j.IdJogadorNavigation)
                .Include(j => j.IdJogoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogoJogadorCartao == null)
            {
                return NotFound();
            }

            return View(jogoJogadorCartao);
        }

        // GET: JogoJogadorCartaos/Create
        public IActionResult Create()
        {
            ViewData["IdCartao"] = new SelectList(_context.Cartao, "Id", "Descricao");
            ViewData["IdJogador"] = new SelectList(_context.Jogador, "Id", "Nome");
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id");
            return View();
        }

        // POST: JogoJogadorCartaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdJogo,IdJogador,IdCartao")] JogoJogadorCartao jogoJogadorCartao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogoJogadorCartao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCartao"] = new SelectList(_context.Cartao, "Id", "Descricao", jogoJogadorCartao.IdCartao);
            ViewData["IdJogador"] = new SelectList(_context.Jogador, "Id", "Nome", jogoJogadorCartao.IdJogador);
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id", jogoJogadorCartao.IdJogo);
            return View(jogoJogadorCartao);
        }

        // GET: JogoJogadorCartaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoJogadorCartao = await _context.JogoJogadorCartao.FindAsync(id);
            if (jogoJogadorCartao == null)
            {
                return NotFound();
            }
            ViewData["IdCartao"] = new SelectList(_context.Cartao, "Id", "Descricao", jogoJogadorCartao.IdCartao);
            ViewData["IdJogador"] = new SelectList(_context.Jogador, "Id", "Nome", jogoJogadorCartao.IdJogador);
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id", jogoJogadorCartao.IdJogo);
            return View(jogoJogadorCartao);
        }

        // POST: JogoJogadorCartaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdJogo,IdJogador,IdCartao")] JogoJogadorCartao jogoJogadorCartao)
        {
            if (id != jogoJogadorCartao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogoJogadorCartao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoJogadorCartaoExists(jogoJogadorCartao.Id))
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
            ViewData["IdCartao"] = new SelectList(_context.Cartao, "Id", "Descricao", jogoJogadorCartao.IdCartao);
            ViewData["IdJogador"] = new SelectList(_context.Jogador, "Id", "Nome", jogoJogadorCartao.IdJogador);
            ViewData["IdJogo"] = new SelectList(_context.Jogo, "Id", "Id", jogoJogadorCartao.IdJogo);
            return View(jogoJogadorCartao);
        }

        // GET: JogoJogadorCartaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoJogadorCartao = await _context.JogoJogadorCartao
                .Include(j => j.IdCartaoNavigation)
                .Include(j => j.IdJogadorNavigation)
                .Include(j => j.IdJogoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogoJogadorCartao == null)
            {
                return NotFound();
            }

            return View(jogoJogadorCartao);
        }

        // POST: JogoJogadorCartaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogoJogadorCartao = await _context.JogoJogadorCartao.FindAsync(id);
            _context.JogoJogadorCartao.Remove(jogoJogadorCartao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoJogadorCartaoExists(int id)
        {
            return _context.JogoJogadorCartao.Any(e => e.Id == id);
        }
    }
}
