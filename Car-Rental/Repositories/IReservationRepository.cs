using Car_Rental.Models;

namespace Car_Rental.Repositories;

public interface IReservationRepository
{
    Task<Reservation> GetReservationByIdAsync(int id);
    Task<IEnumerable<Reservation>> GetAllReservationsAsync();
    Task CreateReservationAsync(Reservation reservation);
    Task UpdateReservationAsync(Reservation reservation);
    Task DeleteReservationAsync(int id);
    Task<DateTime?> GetNextAvailableDateAsync(int carId, DateTime? date);
}