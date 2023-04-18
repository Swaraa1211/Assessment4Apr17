using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Assessment4Apr17.Areas.Identity.Data;
namespace Assessment4Apr17
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("DBEditorContextConnection") ?? throw new InvalidOperationException("Connection string 'DBEditorContextConnection' not found.");

                                    builder.Services.AddDbContext<DBEditorContext>(options =>
                options.UseSqlServer(connectionString));

                                                builder.Services.AddDefaultIdentity<EditorUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<DBEditorContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}