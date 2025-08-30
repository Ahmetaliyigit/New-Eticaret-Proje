using DAL.Concrate.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Server=AHMETALI\\SQLEXPRESS; Database=E-Ticaret_Projesi_AHMT; Trusted_Connection=True; TrustServerCertificate=True;");

        return new DataContext(optionsBuilder.Options);
    }
}
