using System.Security.Claims;
using Car_Rental.DTOs;
using Car_Rental.Pages.InputModels;
using Car_Rental.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_Rental.Pages;

[Authorize]
public class ViewReservations : PageModel
{
    private readonly ICarService _carService;
    public IEnumerable<ReservationDto> ActiveReservations { get; set; }
    
    [BindProperty]
    public UpdateReservationInputModel UpdateReservationInputModel { get; set; }

    public ViewReservations(ICarService carService)
    {
        _carService = carService;
    }

    public async Task OnGetAsync()
    {
        ActiveReservations = await _carService.GetReservationsFromUserAsync(GetCurrentUserId());
    }
    
    private int GetCurrentUserId()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userId ?? throw new InvalidOperationException("User ID not found in claims."));
    }
    
    public async Task<IActionResult> OnPostUpdateReservationAsync(int reservationId, int carId, DateTime newStartDate, DateTime newEndDate)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        if (newStartDate > newEndDate)
        {
            ModelState.AddModelError(string.Empty, "End date cannot be earlier than start date.");
            return Page();
        }
        await _carService.UpdateReservationAsync(reservationId, newStartDate, newEndDate, carId, GetCurrentUserId());
        
        return RedirectToPage();
    }

    
}