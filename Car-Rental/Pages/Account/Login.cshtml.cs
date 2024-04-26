using System.Security.Claims;
using Car_Rental.Pages.InputModels;
using Car_Rental.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Car_Rental.Pages;

public class SignInModel : PageModel
{
    private readonly IUserRepository _userRepository;
    
    public SignInModel(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [BindProperty]
    public LoginInputModel Input { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }


        bool isAuthenticated = await CheckCredentials(Input.Email, Input.Password);

        if (!isAuthenticated)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Input.Email),
            new Claim(ClaimTypes.Email, Input.Email)
            
        };
        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
        var principal = new ClaimsPrincipal(identity);
        
        await HttpContext.SignInAsync("MyCookieAuth", principal);

        return RedirectToPage("/Index");
    }

    private async Task<bool> CheckCredentials(string email, string password)
    {
        var user = await _userRepository.Get(email, password);
        if (user == null)
        {
            return false;
        }
        return true;
    }
}