using Car_Rental.Models;

namespace Car_Rental.Repositories;

public interface ILocationRepository
{
    Task<Location> GetLocationByIdAsync(int id);
    Task<IEnumerable<Location>> GetAllLocationsAsync();
    Task CreateLocationAsync(Location location);
    Task UpdateLocationAsync(Location location);
    Task DeleteLocationAsync(int locationId);
    Task<IEnumerable<string>> GetCountriesAsync();
    Task<IEnumerable<string>> GetCitiesByCountryAsync(string country);

}