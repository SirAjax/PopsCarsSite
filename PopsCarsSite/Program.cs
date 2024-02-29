using EFTest;
using Microsoft.EntityFrameworkCore;
using PopsCars;
using MudBlazor.Services;
using Microsoft.AspNetCore.Server.IISIntegration;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.ConfigRepositoryContext("Server=(localdb)\\MSSQLLocalDB;Database=PopsCars;Trusted_Connection=True;MultipleActiveResultSets=true");
builder.Services.AddTransient<ICarsRepository, CarsRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<INoteRepository, NoteRepository>();
builder.Services.AddTransient<INoteService, NoteService>();
builder.Services.AddMudServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.
builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);

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
app.UseAuthentication();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
// added this for ef core migration
using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<PopsCarsContext>();
	await context.Database.MigrateAsync();
}

app.Run(); 