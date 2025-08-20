using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infrastructure
{
    public class ProductClientHubDbContext : DbContext
    {
        // Indica para o EF Core que eu garanto que essas propriedades serão inicializadas (terão algum valor) antes de serem usadas.
        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MMFS\\SQLEXPRESS;Initial Catalog=ProductClientHub;Integrated Security=True;TrustServerCertificate=true;");
        }
    }
}
