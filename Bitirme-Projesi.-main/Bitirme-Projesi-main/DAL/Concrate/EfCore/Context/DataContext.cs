using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);

            // Cart ve Product arasında many-to-many ilişki
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Carts)
                .UsingEntity(j => j.ToTable("CartProducts")); // Join tablosu ismi
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }



    }

    // Add-migration / Update-Database işlemleri için kullandığım yapı

    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=AHMETALI\\SQLEXPRESS; Database=E-Ticaret_Projesi_AHMT; Trusted_Connection=True; TrustServerCertificate=True;");

            return new DataContext(optionsBuilder.Options);
        }

    }
}
