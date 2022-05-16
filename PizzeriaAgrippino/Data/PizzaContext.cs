using Microsoft.EntityFrameworkCore;

namespace PizzeriaAgrippino.Data
{
    public class PizzaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=AgrippinosPizzaDB;Integrated Security=True");
        }
    }
}

