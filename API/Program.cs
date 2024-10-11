
using Core.Interfaces;
using Infrastructure;
using Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //var host = CreateBuilder(args).Build();
        //using (var scope = host.Services.CreateScope())
        //{
        //    var services = scope.ServiceProvider;
        //    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        //    try
        //    {
        //        var context = services.GetRequiredService<StoreContext>();
        //        await context.Database.MigrateAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        var logger = loggerFactory.CreateLogger<Program>();
        //        logger.LogError(ex, "An Error Occured During Migration");
        //    }
        //}
        //host.Run();

        builder.Services.AddControllers();
         builder.Services.AddScoped<IProductRepository, ProductRepository >();
        builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
       

     
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();





        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}