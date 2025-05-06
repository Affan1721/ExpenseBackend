using Microsoft.EntityFrameworkCore;
using SpendSmart.Models;

namespace SpendSmart.Data
{
    public class SpendSmartDBContext : DbContext
    {
        public DbSet<Expense> Expense { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-3K4RH6I\\SQLEXPRESS;Database=SpendSmartDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public SpendSmartDBContext(DbContextOptions<SpendSmartDBContext> options) : base(options)
        {
        }
    }
}