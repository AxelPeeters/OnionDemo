using Application;
using Application.Cars;
using Application.Cars.Persistence;
using Application.Persistence.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Generic;
using Persistence.Repositories;

namespace Persistence;

public static class DependencyInjection
{
    public static void ConfigureInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(o =>
        {
            o.UseSqlite("Filename=localdb.db");
        });

        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<ICarRepository, CarRepository>();
    }

    public static async void SeedData(IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        await using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (!await context.Database.EnsureCreatedAsync()) return;

        var car = new Car("Mercedes", "CLA");
        car.AddPart("PART0001");
        
        context.Cars.Add(car);
        await context.SaveChangesAsync();
    }
}