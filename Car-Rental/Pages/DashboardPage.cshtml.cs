using System.Security.Claims;
using Car_Rental.DTOs.CarDTOs;
using Car_Rental.DTOs.ReservationDTOs;
using Car_Rental.Enums;
using Car_Rental.Pages.InputModels;
using Car_Rental.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Car_Rental.Pages;

[Authorize]
public class DashboardPage : PageModel
{
    private readonly ICarService _carService;
    private readonly IReservationService _reservationService;
    private readonly ILocationService _locationService;

    public List<SelectListItem> Countries { get; set; } = new List<SelectListItem>();
    public List<SelectListItem> Cities { get; set; } = new List<SelectListItem>();
    public DashboardPage(ICarService carService, IReservationService reservationService, ILocationService locationService)
    {
        _carService = carService;
        _reservationService = reservationService;
        _locationService = locationService;
    }
    
    [BindProperty]
    public MainPageInputModel Input { get; set; }
    public IEnumerable<CarDto> AvailableCars { get; set; }
    
    public async Task OnGetAsync()
    {
        Countries = await _locationService.GetCountriesAsync();
        Cities = new List<SelectListItem>();
    }
    
    public async Task<IActionResult> OnGetCitiesAsync(string country)
    {
        Cities = await _locationService.GetCitiesByCountryAsync(country);
        return new JsonResult(Cities);
    }
    
        private async Task LoadCitiesAndCountriesAsync()
    {
        Countries = await _locationService.GetCountriesAsync();
        Cities = !string.IsNullOrEmpty(Input.Country) ? await _locationService.GetCitiesByCountryAsync(Input.Country) : new List<SelectListItem>();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        await LoadCitiesAndCountriesAsync();
        
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (Input.StartDate > Input.EndDate)
        {
            ModelState.AddModelError(string.Empty, "End date cannot be earlier than start date.");
            return Page();
        }
        
        AvailableCars = await _carService.GetAvailableCarsAsync(Input.City, Input.Country, Input.StartDate, Input.EndDate);
        
        return Page();
    }
    public async Task<IActionResult> OnPostReserveAsync(int carId, DateTime startDate, DateTime endDate)
    {
        var reservationDto = new ReservationForCreationDto()
        {
            CarId = carId,
            UserId = GetCurrentUserId(),
            StartDate = startDate,
            EndDate = endDate,
            ReservationStatus = ReservationStatus.Reserved
        };

        await _reservationService.ReserveCarAsync(reservationDto);

        await LoadCitiesAndCountriesAsync();

        return RedirectToPage();
    }

    private int GetCurrentUserId()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userId ?? throw new InvalidOperationException("User ID not found in claims."));
    }
}
