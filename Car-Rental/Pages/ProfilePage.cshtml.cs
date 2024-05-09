using System.Security.Claims;
using AutoMapper;
using Car_Rental.Pages.InputModels;
using Car_Rental.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IAuthenticationService = Car_Rental.Services.IAuthenticationService;

namespace Car_Rental.Pages;

[Authorize]
public class ProfilePage : PageModel
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;
    
    public ProfilePage(IUserRepository userRepository, IMapper mapper, IAuthenticationService authenticationService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }
    
    [BindProperty]
    public UserUpdateInputModel Input { get; set; }
    
    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userRepository.GetUserByEmailAsync(GetCurrentUserEmail());
        if (user == null)
        {
            return NotFound("User not found.");
        }

        Input = _mapper.Map<UserUpdateInputModel>(user);
        
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _userRepository.GetUserByEmailAsync(GetCurrentUserEmail());
        if (user == null)
        {
            return NotFound("User not found.");
        }

        _mapper.Map(Input, user);
        try
        {
            await _userRepository.UpdateUserAsync(user);
            
            await _authenticationService.RefreshUserClaimsAsync(user);

            return RedirectToPage(); 
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Failed to update user. Please try again.");
            return Page();
        }
    }
    
    private string GetCurrentUserEmail()
    {
        return User.FindFirst(ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("User email not found in claims.");  
    }
}