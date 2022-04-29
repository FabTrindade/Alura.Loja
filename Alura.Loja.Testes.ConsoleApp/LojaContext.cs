using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
            //optionsBuilder.UseSqlServer("Data Source=localdb;Initial Catalog=LojaDB; Integrated Security=true");
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LojaDB; Integrated Security=true");
        }
    }
}