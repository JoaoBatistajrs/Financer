using FinancialManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.Data
{
    public class FinancialManagerDbContext : DbContext
    {
        public FinancialManagerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Bank> Banks { get; set; }
    }
}
