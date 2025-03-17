using CadastroUCEP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUCEP.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(u => u.User_ID);
                entity.Property(u => u.Name).IsRequired();
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.Password).IsRequired();
                entity.Property(u => u.Cep).IsRequired();
                entity.Property(u => u.Street).IsRequired();
                entity.Property(u => u.Number).IsRequired();
                entity.Property(u => u.Neighborhood).IsRequired();
                entity.Property(u => u.City).IsRequired();
                entity.Property(u => u.State).IsRequired();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L43816O;Database=CadastroUCEP;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
