using System.Security.Claims;
using Car_Rental.Pages.InputModels;
using Car_Rental.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_Rental.Pages;

[Authorize]
public class ProfilePage : PageModel
{
    private readonly IUserRepository _userRepository;
    
    public ProfilePage(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [BindProperty]
    public UserUpdateInputModel Input { get; set; }
    
    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userRepository.GetUserByEmailAsync(GetCurrentUserEmail());

        Input = new UserUpdateInputModel()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            AddressOne = user.AddressOne,
            AddressTwo = user.AddressTwo,
            City = user.City,
            Country = user.Country,
            LicenseNumber = user.LicenseNumber
        };

        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _userRepository.GetUserByEmailAsync(GetCurrentUserEmail());

        user.FirstName = Input.FirstName;
        user.LastName = Input.LastName;
        user.PhoneNumber = Input.PhoneNumber;
        user.AddressOne = Input.AddressOne;
        user.AddressTwo = Input.AddressTwo;
        user.City = Input.City;
        user.Country = Input.Country;
        user.LicenseNumber = Input.LicenseNumber;
        
        await _userRepository.UpdateUserAsync(user);

        return RedirectToPage();
    }
    
    private string GetCurrentUserEmail()
    {
        return User.FindFirst(ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("User email not found in claims.");  
    }
}