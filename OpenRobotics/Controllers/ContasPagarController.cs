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
    public class ContasPagarController : Controller
    {
        private readonly Context _context; 

        public ContasPagarController(Context context)
        {
            _context = context;
        }

        // GET: ContasReceber
        public async Task<IActionResult> Index()
        {
              return _context.ContasPagar != null ? 
                          View(_context.GetContasPagar()) :
                          Problem("Entity set 'Context.ContasPagar'  is null.");
        }

        // GET: ContasReceber/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContasPagar == null)
            {
                return NotFound();
            }

            var contasPagar = await _context.ContasPagar
                .FirstOrDefaultAsync(m => m.IdContaPagar == id);
            if (contasPagar == null)
            {
                return NotFound();
            }

            return View(contasPagar);
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
        public async Task<IActionResult> Create([Bind("IdContaPagar,Vencimento,Valor,DataEmissao,NumeroDocumento,Competencia,FormaPagamento,Categoria,Historico,Tipo,Situacao,IdCliente")] ContasPagar contasPagar)
        {
            var cliente = _context.Cliente.Find(contasPagar.IdCliente);
            
            contasPagar.Cliente = cliente;
            try
            {
                _context.Add(contasPagar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(contasPagar);
            }
        }

        // GET: ContasReceber/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContasPagar == null)
            {
                return NotFound();
            }

            var contasPagar = await _context.ContasPagar.FindAsync(id);
            if (contasPagar == null)
            {
                return NotFound();
            }
            ViewBag.Cliente = new SelectList(_context.Cliente, "Id", "Nome");
            return View(contasPagar);
        }

        // POST: ContasReceber/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContaPagar,Vencimento,Valor,DataEmissao,NumeroDocumento,Competencia,FormaPagamento,Categoria,Historico,Tipo,Situacao,IdCliente")] ContasPagar contasPagar)
        {
            if (id != contasPagar.IdContaPagar)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    _context.Update(contasPagar);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(contasPagar);
                    //if (!ContasReceberExists(contasPagar.IdContaPagar))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
            }
        }

        // GET: ContasReceber/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContasPagar == null)
            {
                return NotFound();
            }

            var contasPagar = await _context.ContasPagar
                .FirstOrDefaultAsync(m => m.IdContaPagar == id);
            if (contasPagar == null)
            {
                return NotFound();
            }

            return View(contasPagar);
        }

        // POST: ContasReceber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContasPagar == null)
            {
                return Problem("Entity set 'Context.ContasReceber'  is null.");
            }
            var contasPagar = await _context.ContasPagar.FindAsync(id);
            if (contasPagar != null)
            {
                _context.ContasPagar.Remove(contasPagar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContasReceberExists(int id)
        {
          return (_context.ContasPagar?.Any(e => e.IdContaPagar == id)).GetValueOrDefault();
        }
    }
}
