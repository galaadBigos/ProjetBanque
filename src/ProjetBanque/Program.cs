using ProjetBanque.Abstractions.DAO;
using ProjetBanque.Abstractions.Services;
using ProjetBanque.Data;
using ProjetBanque.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IBanqueDAO, BanqueDAO>();
builder.Services.AddScoped<IBanqueService, BanqueService>();
builder.Services.AddScoped<IDataBase, DbFake>();

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
