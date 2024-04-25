using Car_Rental.Models;

namespace Car_Rental.Repositories;

public interface ICarRepository
{
    Task<Car> GetCarByIdAsync(int id);
    Task<IEnumerable<Car>> GetAllCarsAsync();
    Task CreateCarAsync(Car car);
    Task UpdateCarAsync(Car car);
    Task DeleteCarAsync(int carId);
}