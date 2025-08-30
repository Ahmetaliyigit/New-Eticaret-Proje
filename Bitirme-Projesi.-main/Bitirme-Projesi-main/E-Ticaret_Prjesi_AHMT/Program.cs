using BLL.Abstract;
using BLL.Service;
using DAL.Abstract;
using DAL.Concrate.EfCore;
using DAL.Concrate.EfCore.Context;
using DAL.EfCore;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret_Prjesi_AHMT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddHttpClient();       
            builder.Services.AddDbContext<DataContext>(opts =>
            opts.UseSqlServer(builder.Configuration.GetConnectionString("ProjectConnection"))); // appsetting.json a giderek oradan Proje baglantisini alir ve a�a��da belirtilen S�n�fa yollan�r 

            
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
                

            builder.Services.AddScoped<ICategoryDAL,CategoryDAL>();
            builder.Services.AddScoped<IColorDAL,ColorDAL>();
            builder.Services.AddScoped<IProductDAL,ProductDAL>();
            builder.Services.AddScoped<IGenderDAL,GenderDAL>();
            builder.Services.AddScoped<ICountryDAL,CountryDAL> ();

            builder.Services.AddScoped<ICategoryService,CategoryService>();
            builder.Services.AddScoped<IColorService,ColorService>();
            builder.Services.AddScoped<IGenderService,GenderService>();
            builder.Services.AddScoped<IProductService,ProductService>();
            builder.Services.AddScoped<ICountryService, ContryService>();



            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
