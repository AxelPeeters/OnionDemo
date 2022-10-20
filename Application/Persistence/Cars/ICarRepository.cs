using Domain;

namespace Application.Cars.Persistence;

public interface ICarRepository
{
    Task<List<Car>> GetCars();
    Task<Car> GetCarById(int id);
    Task AddCar(Car car);
}