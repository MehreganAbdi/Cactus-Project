using CactusDomain.IRepository;
using CactusApplication.IService;
using CactusApplication.Repository;
using CactusApplication.Service;
using CactusDomain.Data;
using CactusDomain.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CactusDomain.CloudinarySetup;

namespace Cactus
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();




            #region DI


            //Repositories

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IUserDashBoardRepository, UserDashBoardRepository>();
            builder.Services.AddScoped<IAdminDashBoardRepository, AdminDashBoardRepository>();



            //Services

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IUserFavoriteService, UserFavoriteService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IPhotoService, PhotoService>();
            builder.Services.AddScoped<IUserDashBoardService , UserDashBoardService>();
            builder.Services.AddScoped<IAdminDashBoardService, AdminDashBoardService>();

            #endregion





            #region Configs


            //Cloudinay
            builder.Services.Configure<CloudinarySetup>(builder.Configuration.GetSection("CloudinarySetup"));
            

            //Data-Base
            builder.Services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });


            //Identity
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddMemoryCache();

            builder.Services.AddSession();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


            #endregion





            var app = builder.Build();

            if (args.Length == 1 && args[0].ToLower() == "seeddata")
            {
                await SeedData.SeedUsersAndRolesAsync(app);
            }


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