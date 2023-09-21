using EFTest;
using Microsoft.EntityFrameworkCore;
using PopsCars;
using PopsCarsSite.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigRepositoryContext("Server=(localdb)\\MSSQLLocalDB;Database=PopsCars;Trusted_Connection=True;MultipleActiveResultSets=true");
builder.Services.AddTransient<ICarsRepository, CarsRepository>();
builder.Services.AddTransient<IService, Service>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// added this for ef core migration
using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<PopsCarsContext>();
	await context.Database.MigrateAsync();
}

app.Run();
