using Car_Rental.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Car_Rental.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    
    public LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    
    public async Task<List<SelectListItem>> GetCountriesAsync()
    {
        var countries = await _locationRepository.GetCountriesAsync();
        return countries.Select(country => new SelectListItem
        {
            Value = country,
            Text = country
        }).ToList();
    }
    
    public async Task<List<SelectListItem>> GetCitiesByCountryAsync(string country)
    {
        var cities = await _locationRepository.GetCitiesByCountryAsync(country);
        return cities.Select(city => new SelectListItem
        {
            Value = city,
            Text = city
        }).ToList();
    }

}