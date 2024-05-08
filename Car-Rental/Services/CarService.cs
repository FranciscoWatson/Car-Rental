using Car_Rental.DTOs;
using Car_Rental.DTOs.CarDTOs;
using Car_Rental.DTOs.ReservationDTOs;
using Car_Rental.Enums;
using Car_Rental.Models;
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
    
    public async Task ReserveCarAsync(ReservationForCreationDto reservationDto)
    {
        var reservation = new Reservation
        {
            CarId = reservationDto.CarId,
            UserId = reservationDto.UserId,
            StartDate = reservationDto.StartDate,
            EndDate = reservationDto.EndDate,
            ReservationStatus = reservationDto.ReservationStatus
        };

        await _reservationRepository.CreateReservationAsync(reservation);
    }
    
    public async Task<IEnumerable<ReservationDto>> GetReservationsFromUserAsync(int userId)
    {
        var reservations = await _reservationRepository.GetAllReservationsFromUserAsync(userId);
        return reservations.Select(r => new ReservationDto
        {
            ReservationId = r.ReservationId,
            CarModel = $"{r.Car.Make}, {r.Car.Model}",
            Location = $"{r.Car.Location.City}, {r.Car.Location.Country}",
            StartDate = r.StartDate,
            EndDate = r.EndDate,
            Status = r.ReservationStatus.ToString(),
            CarId = r.CarId
        }).ToList();
    }

    public async Task UpdateReservationAsync(int reservationId, DateTime startDate, DateTime endDate, int carId, int userId)
    {
        var reservation = new Reservation
        {
            UserId = userId,
            ReservationId = reservationId,
            StartDate = startDate,
            EndDate = endDate,
            CarId = carId,
            ReservationStatus = ReservationStatus.Reserved
        };
        await _reservationRepository.UpdateReservationAsync(reservation);
    }
}
