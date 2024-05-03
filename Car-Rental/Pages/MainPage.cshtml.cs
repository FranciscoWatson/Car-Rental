using System.Security.Claims;
using Car_Rental.DTOs;
using Car_Rental.DTOs.CarDTOs;
using Car_Rental.DTOs.ReservationDTOs;
using Car_Rental.Enums;
using Car_Rental.Pages.InputModels;
using Car_Rental.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_Rental.Pages;

[Authorize]
public class MainPage : PageModel
{
    private readonly ICarService _carService;

    
    public MainPage(ICarService carService)
    {
        _carService = carService;
    }
    
    [BindProperty]
    public MainPageInputModel Input { get; set; }
    
    public IEnumerable<CarDto> AvailableCars { get; set; }
    public IEnumerable<ReservationDto> ActiveReservations { get; set; }

    public async Task OnGetAsync()
    {
        ActiveReservations = await _carService.GetReservationsFromUserAsync(GetCurrentUserId());
    }
    public async Task<IActionResult> OnPostAsync()
    {
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
        ActiveReservations = await _carService.GetReservationsFromUserAsync(GetCurrentUserId());


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

        await _carService.ReserveCarAsync(reservationDto);
        ActiveReservations = await _carService.GetReservationsFromUserAsync(GetCurrentUserId());

        return RedirectToPage();
    }

    private int GetCurrentUserId()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userId ?? throw new InvalidOperationException("User ID not found in claims."));
    }
    
}
