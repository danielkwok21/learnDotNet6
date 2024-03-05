using BuberBreakfast.Data;
using BuberBreakfast.Services.Breakfasts;
using BuberBreakfast.Services.ShopService;
using BuberShop.Services.Shops;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddControllers();

    // specify such that within a single request, whenever IBreakfastService is called, instantiate BreakfastService
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
    builder.Services.AddScoped<IShopService, ShopService>();

    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.MapControllers();

    app.MapRazorPages();

    app.Run();
}
