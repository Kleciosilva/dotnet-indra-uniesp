using Microsoft.EntityFrameworkCore;
using System;

namespace Backend
{
    public class VehiclesContext : DbContext
    {
        public DbSet<CarModel> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=.\SQLEXPRESS;Database=ProjetoDeCurso;Trusted_Connection = true");
        }
    }
}
