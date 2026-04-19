using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data;
using StockMePhotos.Data.Models;
using StockMePhotos.Data.Seeding;
using StockMePhotos.Data.Seeding.Contracts;
using StockMePhotos.GCommon;
using StockMePhotos.Services.Common;
using StockMePhotos.Services.Core;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.Web.Infrastructure;

namespace StockMePhotos.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string? connectionString = builder.Configuration
                .GetConnectionString("DefaultDevConnection");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<StockMePhotosDbContext>(options =>
            {
                options
                    .UseSqlServer(connectionString);
            });

            builder.Services
                 .AddDefaultIdentity<ApplicationUser>(options =>
                 {
                     ConfigureIdentityOptions(builder.Configuration, options);
                 })
                 .AddRoles<IdentityRole<Guid>>()
                 .AddEntityFrameworkStores<StockMePhotosDbContext>()
                 .AddDefaultTokenProviders()
                 .AddDefaultUI();

            builder.Services.AddScoped<IPhotoService, PhotoService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IPhotoUploadService, PhotoUploadService>();
            builder.Services.AddScoped<IPhotoCategoryService, PhotoCategoryService>();
            builder.Services.AddScoped<IFavoritePhotoService, FavoritePhotoService>();

            builder.Services.AddTransient<IRolesSeeder, RolesSeeder>();
            builder.Services.AddTransient<IUsersSeeder, UsersSeeder>();
            builder.Services.AddTransient<IUsersToRolesSeeder, UsersToRolesSeeder>();
            builder.Services.AddTransient<IIdentitySeeder, IdentitySeeder>();

            /* Cloudinary */
            builder.Services.Configure<CloudinarySettings>(
                builder.Configuration.GetSection("Cloudinary")
            );
            builder.Services.AddScoped<CloudinaryService>();

            WebApplication app = builder.Build();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseIdentitySeeder();

            app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");

            app.MapControllerRoute(
               name: "adminArea",
               pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        private static void ConfigureIdentityOptions(ConfigurationManager configuration,
           IdentityOptions options)
        {
            options.SignIn.RequireConfirmedAccount = configuration
                .GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
            options.SignIn.RequireConfirmedEmail = configuration
                .GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");
            options.SignIn.RequireConfirmedPhoneNumber = configuration
                .GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");

            options.Password.RequireDigit = configuration
                .GetValue<bool>("Identity:Password:RequireDigit");
            options.Password.RequiredLength = configuration
                .GetValue<int>("Identity:Password:RequiredLength");
            options.Password.RequiredUniqueChars = configuration
                .GetValue<int>("Identity:Password:RequiredUniqueChars");
            options.Password.RequireNonAlphanumeric = configuration
                .GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
            options.Password.RequireUppercase = configuration
                .GetValue<bool>("Identity:Password:RequireUppercase");
            options.Password.RequireLowercase = configuration
                .GetValue<bool>("Identity:Password:RequireLowercase");
        }
    }
}
