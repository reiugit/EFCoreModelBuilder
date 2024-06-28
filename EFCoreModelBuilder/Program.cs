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
        //use 'docker compose up' to create a local SqlServer-Database
        return Results.BadRequest(new
        {
            Info = " This application needs a local SqlServer-Database. ",
            _ = "",
            Todo1 = " 1.) Use  'DOCKER compose up --detach'  to create a local SqlServer instance. ",
            Todo2 = " 2.) Use  'EFCore Migrations' to create a valid database: ",
            Todo3 = " -- with  'ef migrations database update'  in EFCore Tools ",
            Todo4 = " -- or  'update-database'  in the Package Manager Console ",
        });
    }
});

app.Run();


