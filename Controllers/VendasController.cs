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
    public class VendasController : Controller
    {
        private readonly MvcContext _context;

        public VendasController(MvcContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index(string searchString, string produtoDsc)
        {
            
            //Search by customer name
            if (!String.IsNullOrEmpty(searchString))
            {
                var sales = from m in _context.Vendas
                select m;

                sales = sales
                .Where(s => s.Cliente.NnCliente!.Contains(searchString));
                
                return View(await sales.ToListAsync());
            }
            
            //Search by product descriptiom
            if (!String.IsNullOrEmpty(produtoDsc))
            {
                var sales = from m in _context.Vendas
                select m;

                sales = sales
                .Where(s => s.Produto.DscProduto!.Contains(produtoDsc));
                
                return View(await sales.ToListAsync());
            }
            
            //Default sales
            else{
                var sale = _context.Vendas
                .Include(s => s.Cliente)
                .Include(s => s.Produto).ToListAsync();

                return View(await sale);
            }
        }

        // GET: Vendas/Create
       
        public IActionResult AddOrEdit(int id=0)
        {
            if(id == 0) return View(new Venda());
            else return View(_context.Vendas.Find(id));
        }  

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdCliente,IdProduto,QtdVenda,VlrUnitario,DthVenda,VlrTotalVenda")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                if(venda.IdVenda == 0)
                _context.Add(venda);
                else
                _context.Update(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }
        
        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}