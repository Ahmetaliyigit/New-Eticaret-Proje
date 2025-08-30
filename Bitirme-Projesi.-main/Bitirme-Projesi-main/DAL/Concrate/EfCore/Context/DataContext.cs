using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrate.EfCore.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=AHMETALI\\SQLEXPRESS; Database=E-Ticaret_Projesi_AHMT; Trusted_Connection=True; TrustServerCertificate=True;");
        //}

        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ApplicationUser ve Cart arasında 1-1 ilişki
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Carts)       // User -> Cart
                .WithOne(c => c.User)       // Cart -> User
                .HasForeignKey<Cart>(c => c.UserId); // Foreign key Cart tablosunda
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Product> Products { get; set; }



    }
}
