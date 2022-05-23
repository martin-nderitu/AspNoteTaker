using Microsoft.EntityFrameworkCore;
using NoteTaker.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opts =>
{
    if (builder.Environment.IsDevelopment())
    {
        builder.Configuration.AddUserSecrets<Program>(true);
    }

    string dbUrl = builder.Configuration.GetConnectionString("DATABASE_URL");
    var connectionString = Configuration.GetConnectionString(dbUrl);
    opts.UseNpgsql(connectionString);
});

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

if (app.Environment.IsDevelopment())
{
    SeedData.SeedDatabase(context);
}
else
{
    try
    {
        context.Database.Migrate();
    }
    catch
    {
    }
}

app.Run();