using Car_Rental.DTOs;
using Car_Rental.Repositories;

namespace Car_Rental.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IReservationRepository _reservationRepository;

    public CarService(ICarRepository carRepository, IReservationRepository reservationRepository)
    {
        _carRepository = carRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<IEnumerable<CarDto>> GetAvailableCarsAsync(string city, string country, DateTime? date)
    {
        var cars = await _carRepository.GetAvailableCarsAsync(city, country, date);
        var carDtos = new List<CarDto>();
        
        foreach (var car in cars)
        {
            var nextAvailableDate = await _reservationRepository.GetNextAvailableDateAsync(car.CarId, date);
            carDtos.Add(new CarDto
            {
                CarId = car.CarId,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                LocationCity = car.Location.City,
                LocationCountry = car.Location.Country,
                NextAvailableDate = nextAvailableDate
            });
        }

        return carDtos;
    }
}
