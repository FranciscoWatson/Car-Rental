using System.Security.Claims;
using Car_Rental.Models;
using Car_Rental.Pages.InputModels;
using Car_Rental.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IAuthenticationService = Car_Rental.Services.IAuthenticationService;


namespace Car_Rental.Pages;

public class SignInModel : PageModel
{
    private readonly IAuthenticationService _authenticationService;
    
    public SignInModel(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    [BindProperty]
    public LoginInputModel Input { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var result = await _authenticationService.SignInAsync(Input.Email, Input.Password);
        
        if (!result)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
        
        return RedirectToPage("/Index");
    }
}