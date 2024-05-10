using Microsoft.AspNetCore.Mvc.Rendering;

namespace Car_Rental.Services;

public interface ILocationService
{
    Task<List<SelectListItem>> GetCitiesByCountryAsync(string country);
    Task<List<SelectListItem>> GetCountriesAsync();
}