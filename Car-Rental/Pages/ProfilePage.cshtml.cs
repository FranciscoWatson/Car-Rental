using System.Security.Claims;
using AutoMapper;
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
    private readonly IMapper _mapper;
    
    public ProfilePage(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
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
        await _userRepository.UpdateUserAsync(user);

        return RedirectToPage();
    }
    
    private string GetCurrentUserEmail()
    {
        return User.FindFirst(ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("User email not found in claims.");  
    }
}