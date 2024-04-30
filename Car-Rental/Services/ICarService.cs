using Car_Rental.DTOs;

namespace Car_Rental.Services;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAvailableCarsAsync(string city, string country, DateTime? date);
}