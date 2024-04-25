using Car_Rental.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly CarRentalDbContext _carRentalDbContext;
    
    public LocationRepository(CarRentalDbContext carRentalDbContext)
    {
        _carRentalDbContext = carRentalDbContext;
    }
    
    public async Task<Location> GetLocationByIdAsync(int id)
    {
        return await _carRentalDbContext.Locations.FindAsync(id);
    }

    public async Task<IEnumerable<Location>> GetAllLocationsAsync()
    {
        return await _carRentalDbContext.Locations.ToListAsync();
    }

    public async Task CreateLocationAsync(Location location)
    {
        await _carRentalDbContext.Locations.AddAsync(location);
        await _carRentalDbContext.SaveChangesAsync();
    }

    public async Task UpdateLocationAsync(Location location)
    {
        _carRentalDbContext.Locations.Update(location);
        await _carRentalDbContext.SaveChangesAsync();
    }

    public async Task DeleteLocationAsync(int locationId)
    {
        var location = await _carRentalDbContext.Locations.FindAsync(locationId);
        if (location != null)
        {
            _carRentalDbContext.Locations.Remove(location);
            await _carRentalDbContext.SaveChangesAsync();
        }
    }
}