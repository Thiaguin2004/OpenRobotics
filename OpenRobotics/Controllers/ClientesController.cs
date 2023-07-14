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
    public class ClientesController : Controller
    {
        private readonly Context _context;

        public ClientesController(Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(_context.GetCliente());
        }

        // GET: Usuarios/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    var cliente = await _context.Cliente
        //        .Include(u => u.Perfil)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cliente);
        //}

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            //ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "Descricao");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Fantasia,TipoPessoa,CEP,UF,Cidade,Bairro,Endereco,Numero,Complemento,Celular,CPF,Desligado,CNPJCPF")] Cliente cliente)
        {
            try
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            //ViewBag.Perfis = new SelectList(_context.GetPerfis(), "IdPerfil", "Descricao");
            return View(cliente);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Fantasia,TipoPessoa,CEP,UF,Cidade,Bairro,Endereco,Numero,Complemento,Celular,CPF,Desligado,CNPJCPF")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(cliente);
                    //if (!UsuarioExists(usuario.Id))
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

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = _context.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cliente == null)
            {
                return Problem("Entity set 'Context.Cliente'  is null.");
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Cliente?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlterarDesligamento(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente.Desligado == 1)
                cliente.Desligado = 0;
            else
                cliente.Desligado = 1;
            try
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return View(cliente);
            }
        }
    }
}
