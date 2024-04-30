using System.ComponentModel.DataAnnotations;
using Car_Rental.DTOs;
using Car_Rental.Models;
using Car_Rental.Pages.InputModels;
using Car_Rental.Repositories;
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

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        AvailableCars = await _carService.GetAvailableCarsAsync(Input.City, Input.Country, Input.Date);
        
        return Page();
    }
    
}
