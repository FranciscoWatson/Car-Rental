using Car_Rental.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly CarRentalDbContext _carRentalDbContext;
    
    public ReservationRepository(CarRentalDbContext carRentalDbContext)
    {
        _carRentalDbContext = carRentalDbContext;
    }
    
    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        return await _carRentalDbContext.Reservations.FindAsync(id);
    }

    public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
    {
        return await _carRentalDbContext.Reservations.ToListAsync();
    }

    public async Task CreateReservationAsync(Reservation reservation)
    {
        await _carRentalDbContext.Reservations.AddAsync(reservation);
        await _carRentalDbContext.SaveChangesAsync();
    }

    public async Task UpdateReservationAsync(Reservation reservation)
    {
        _carRentalDbContext.Reservations.Update(reservation);
        await _carRentalDbContext.SaveChangesAsync();
    }

    public async Task DeleteReservationAsync(int id)
    {
        var reservation = await _carRentalDbContext.Reservations.FindAsync(id);
        if (reservation != null)
        {
            _carRentalDbContext.Reservations.Remove(reservation);
            await _carRentalDbContext.SaveChangesAsync();
        }
    }
    
}