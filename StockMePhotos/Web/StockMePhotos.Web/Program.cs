using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data;
using StockMePhotos.GCommon;
using StockMePhotos.Services.Common;
using StockMePhotos.Services.Core;
using StockMePhotos.Services.Core.Interfaces;

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
                 .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                 .AddEntityFrameworkStores<StockMePhotosDbContext>()
                 .AddDefaultTokenProviders()
                 .AddDefaultUI();

            builder.Services.AddScoped<IPhotoService, PhotoService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IPhotoUploadService, PhotoUploadService>();
            builder.Services.AddScoped<IPhotoCategoryService, PhotoCategoryService>();
            builder.Services.AddScoped<IFavoritePhotoService, FavoritePhotoService>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
