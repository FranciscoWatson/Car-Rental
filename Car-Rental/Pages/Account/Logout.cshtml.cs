using Car_Rental.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_Rental.Pages;

public class Logout : PageModel
{
    private readonly IAuthenticationService _authenticationService;
    
    public Logout(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    public async Task<IActionResult> OnPostAsync()
    {
        await _authenticationService.SignOutAsync();
        return RedirectToPage("/Index");
    }
}