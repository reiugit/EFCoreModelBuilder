using Microsoft.EntityFrameworkCore;
using EFCoreModelBuilder;
using EFCoreModelBuilder.Entities;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCoreModelBuilder;Integrated Security=True;"
var connectionString = "Server=.;Initial Catalog=EFCoreModelBuilder;TrustServerCertificate=True;Connect Timeout=5;Encrypt=False;User=sa;Password=Password1#;";

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();


app.MapGet("/", (AppDbContext context) =>
{
    // Class AProduct is configured mostly with 'data annotations'
    // Class BProduct is configured only within the 'modelBuilder' in AppDbContext.OnModelCreating
    try
    {
        var aProduct = context.AProducts.FirstOrDefault();
        var bProduct = context.Set<BProduct>().FirstOrDefault();

        return Results.Ok(new { AProduct = aProduct, BProduct = bProduct });
    }
    catch
    {
        //Use 'Docker compose' and 'EFCore-Migrations' to create a local SqlServer-Database
        return Results.BadRequest(DockerAndMigrationInfo.Info);
    }
});

app.Run();


