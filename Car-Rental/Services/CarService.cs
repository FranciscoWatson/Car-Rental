using Car_Rental.DTOs.CarDTOs;
using Car_Rental.Repositories;

namespace Car_Rental.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository, IReservationRepository reservationRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<CarDto>> GetAvailableCarsAsync(string city, string country, DateTime startDate, DateTime endDate)
    {
        var cars = await _carRepository.GetAvailableCarsAsync(city, country, startDate, endDate);
        var carDtos = new List<CarDto>();
        
        foreach (var car in cars)
        {
            carDtos.Add(new CarDto
            {
                CarId = car.CarId,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                LocationCity = car.Location.City,
                LocationCountry = car.Location.Country
            });
        }

        return carDtos;
    }
}
