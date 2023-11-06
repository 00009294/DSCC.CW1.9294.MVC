using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<Owner> Owners { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost; " +
                "Database=DSaCC-db; " +
                "Trusted_Connection=True; " +
                "TrustServerCertificate=true");
        }
    }
}