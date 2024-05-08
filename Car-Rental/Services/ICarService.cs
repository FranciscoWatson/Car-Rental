using Car_Rental.DTOs.CarDTOs;

namespace Car_Rental.Services;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAvailableCarsAsync(string city, string country, DateTime startDate, DateTime endDate);
    
}