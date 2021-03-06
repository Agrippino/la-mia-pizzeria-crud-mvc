using Microsoft.EntityFrameworkCore;
using PizzeriaAgrippino.Models;

namespace PizzeriaAgrippino.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizze> Pizzas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=AgrippinosPizzaDB;Integrated Security=True");
        }
    }
}

