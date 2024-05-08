using Car_Rental.DTOs;
using Car_Rental.DTOs.ReservationDTOs;

namespace Car_Rental.Services;

public interface IReservationService
{
    Task ReserveCarAsync(ReservationForCreationDto reservationDto);
    Task<IEnumerable<ReservationDto>> GetReservationsFromUserAsync(int userId);
    Task UpdateReservationAsync(int reservationId, DateTime startDate, DateTime endDate, int carId, int userId);
}