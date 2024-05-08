using Car_Rental.DTOs;
using Car_Rental.DTOs.CarDTOs;
using Car_Rental.DTOs.ReservationDTOs;

namespace Car_Rental.Services;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAvailableCarsAsync(string city, string country, DateTime startDate, DateTime endDate);
    Task ReserveCarAsync(ReservationForCreationDto reservationDto);
    Task<IEnumerable<ReservationDto>> GetReservationsFromUserAsync(int userId);
    Task UpdateReservationAsync(int reservationId, DateTime startDate, DateTime endDate, int carId, int userId);
}