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
    public class CartaosController : Controller
    {
        private readonly CampeonatoContext _context;

        public CartaosController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: Cartaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cartao.ToListAsync());
        }

        // GET: Cartaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartao = await _context.Cartao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartao == null)
            {
                return NotFound();
            }

            return View(cartao);
        }

        // GET: Cartaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartao);
        }

        // GET: Cartaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartao = await _context.Cartao.FindAsync(id);
            if (cartao == null)
            {
                return NotFound();
            }
            return View(cartao);
        }

        // POST: Cartaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Cartao cartao)
        {
            if (id != cartao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaoExists(cartao.Id))
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
            return View(cartao);
        }

        // GET: Cartaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartao = await _context.Cartao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartao == null)
            {
                return NotFound();
            }

            return View(cartao);
        }

        // POST: Cartaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartao = await _context.Cartao.FindAsync(id);
            _context.Cartao.Remove(cartao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartaoExists(int id)
        {
            return _context.Cartao.Any(e => e.Id == id);
        }
    }
}
