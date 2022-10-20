using Application.Cars.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CarRepository : ICarRepository
{
    private readonly DbSet<Car> _cars;

    public CarRepository(ApplicationDbContext context)
    {
        _cars = context.Cars;
    }

    public async Task<List<Car>> GetCars()
    {
        //Parts not included
        
        return await _cars
            .ToListAsync();
    }

    public async Task<Car> GetCarById(int id)
    {
        //Parts included
        
        return await _cars
            .Include(x => x.Parts)
            .SingleAsync(x => x.Id == id);
    }

    public async Task AddCar(Car car)
    {
        await _cars.AddAsync(car);
    }
}