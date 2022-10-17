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
    public class ProdutosController : Controller
    {
        private readonly MvcContext _context;

        public ProdutosController(MvcContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                var produtos = from m in _context.Produtos
                select m;

                produtos = produtos.Where(s => s.DscProduto!.Contains(searchString));
                return View(await produtos.ToListAsync());
            }
            else{
            return View(await _context.Produtos.ToListAsync());
             }
            }  

            


        // GET: Produtos/Create
        public IActionResult AddOrEdit(int id=0)
        {
            if(id == 0) return View(new Produto());
            else return View(_context.Produtos.Find(id));
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdProduto,DscProduto,VlrUnitario")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                if(produto.IdProduto == 0)
                _context.Add(produto);
                else
                _context.Update(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
