using Car_Rental.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental.Repositories;

public class CarRepository : ICarRepository
{
    private readonly CarRentalDbContext _carRentalDbContext;
    
    public CarRepository(CarRentalDbContext carRentalDbContext)
    {
        _carRentalDbContext = carRentalDbContext;
    }
    
    public async Task<Car> GetCarByIdAsync(int id)
    {
        return await _carRentalDbContext.Cars.FindAsync(id);
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return await _carRentalDbContext.Cars.ToListAsync();
    }

    public async Task CreateCarAsync(Car car)
    {
        await _carRentalDbContext.Cars.AddAsync(car);
        await _carRentalDbContext.SaveChangesAsync();
    }

    public async Task UpdateCarAsync(Car car)
    {
        _carRentalDbContext.Cars.Update(car);
        await _carRentalDbContext.SaveChangesAsync();
    }

    public async Task DeleteCarAsync(int carId)
    {
        var car = await _carRentalDbContext.Cars.FindAsync(carId);
        if (car != null)
        {
            _carRentalDbContext.Cars.Remove(car);
            await _carRentalDbContext.SaveChangesAsync();
        }
    }
}