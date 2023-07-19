using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenRobotics.Models;

namespace OpenRobotics.Controllers
{
    public class ContasReceberController : Controller
    {
        private readonly Context _context; 

        public ContasReceberController(Context context)
        {
            _context = context;
        }

        // GET: ContasReceber
        public async Task<IActionResult> Index()
        {
              return _context.ContasReceber != null ? 
                          View(_context.GetContasReceber()) :
                          Problem("Entity set 'Context.ContasReceber'  is null.");
        }

        // GET: ContasReceber/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContasReceber == null)
            {
                return NotFound();
            }

            var contasReceber = await _context.ContasReceber
                .FirstOrDefaultAsync(m => m.IdContaReceber == id);
            if (contasReceber == null)
            {
                return NotFound();
            }

            return View(contasReceber);
        }

        // GET: ContasReceber/Create
        public IActionResult Create()
        {
            ViewBag.Cliente = new SelectList(_context.Cliente, "Id", "Nome");
            return View();
        }

        // POST: ContasReceber/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContaReceber,Vencimento,Valor,DataEmissao,NumeroDocumento,Competencia,FormaPagamento,Categoria,Historico,Tipo,Situacao,IdCliente")] ContasReceber contasReceber)
        {
            var cliente = _context.Cliente.Find(contasReceber.IdCliente);
            
            contasReceber.Cliente = cliente;
            try
            {
                _context.Add(contasReceber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(contasReceber);
            }
        }

        // GET: ContasReceber/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContasReceber == null)
            {
                return NotFound();
            }

            var contasReceber = await _context.ContasReceber.FindAsync(id);
            if (contasReceber == null)
            {
                return NotFound();
            }
            ViewBag.Cliente = new SelectList(_context.Cliente, "Id", "Nome");
            return View(contasReceber);
        }

        // POST: ContasReceber/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContaReceber,Vencimento,Valor,DataEmissao,NumeroDocumento,Competencia,FormaPagamento,Categoria,Historico,Tipo,Situacao,IdCliente")] ContasReceber contasReceber)
        {
            if (id != contasReceber.IdContaReceber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contasReceber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContasReceberExists(contasReceber.IdContaReceber))
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
            return View(contasReceber);
        }

        // GET: ContasReceber/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContasReceber == null)
            {
                return NotFound();
            }

            var contasReceber = await _context.ContasReceber
                .FirstOrDefaultAsync(m => m.IdContaReceber == id);
            if (contasReceber == null)
            {
                return NotFound();
            }

            return View(contasReceber);
        }

        // POST: ContasReceber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContasReceber == null)
            {
                return Problem("Entity set 'Context.ContasReceber'  is null.");
            }
            var contasReceber = await _context.ContasReceber.FindAsync(id);
            if (contasReceber != null)
            {
                _context.ContasReceber.Remove(contasReceber);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContasReceberExists(int id)
        {
          return (_context.ContasReceber?.Any(e => e.IdContaReceber == id)).GetValueOrDefault();
        }
    }
}
