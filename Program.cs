

using GameZone.Services.Games;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<ICategoryService, CategoryServices>();
        builder.Services.AddScoped<IDeviceServices, DeviceServices>();
        builder.Services.AddScoped<IGameServices, GameServices>();
        //builder.Services.AddScoped<IGameServices,GameServices>();

        // Add services to the container.
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}