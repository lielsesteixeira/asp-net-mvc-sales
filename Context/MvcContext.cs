using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using csharp.Models;

namespace csharp.Context
{
    public class MvcContext : DbContext
    {
        public MvcContext(DbContextOptions<MvcContext> options) : base(options)
        {
            
        }

        public DbSet<Cliente> Customers {get;set;}
        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Venda> Vendas {get; set;}
    }
}