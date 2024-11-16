using Microsoft.EntityFrameworkCore;
using Metricas.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Metricas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar relaciones y restricciones si es necesario
            modelBuilder.Entity<Log>()
                .HasOne(log => log.User)
                .WithMany()
                .HasForeignKey(log => log.UserId)
                .OnDelete(DeleteBehavior.SetNull); // Deja el campo como NULL si el usuario es eliminado
        }
    }
}
