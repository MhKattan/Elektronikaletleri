using BusinessLayer.Common;
using DataAccessLayer.Data;
using DataAccessLayer.Repository;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elektronik_aletleri
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
            builder.Services.AddScoped<IProductRepository,ProductRepository>();
            builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
            builder.Services.AddScoped<ICompanyRepositorycs,CompanyRepository>();
            builder.Services.AddScoped<ISaleRepository, SaleRepository>();
            builder.Services.AddScoped<IPersonelRepository, PersonelRepository>();
            builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.IsEssential = true;

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
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}