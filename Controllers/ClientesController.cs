using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csharp.Context;
using csharp.Models;

namespace csharp.Controllers
{
    public class ClientesController : Controller
    {
        private readonly MvcContext _context;

        public ClientesController(MvcContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                var customers = from m in _context.Customers
                select m;

                customers = customers.Where(s => s.NnCliente!.Contains(searchString));
                return View(await customers.ToListAsync());
            }
            else{
            return View(await _context.Customers.ToListAsync());
             }
            }  

        // GET: Clientes/Create
        public IActionResult AddOrEdit(int id=0)
        {
            if(id == 0) return View(new Cliente());
            else return View(_context.Customers.Find(id));
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdCliente,NnCliente,Cidade")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if(cliente.IdCliente == 0)
                _context.Add(cliente);
                else
                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var cliente = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
