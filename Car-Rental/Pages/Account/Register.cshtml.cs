using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Car_Rental.Models;
using Car_Rental.Pages.InputModels;
using Car_Rental.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Car_Rental.Pages;

public class Register : PageModel
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public Register(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    [BindProperty]
    public RegisterInputModel Input { get; set; }
    
    public List<SelectListItem> Countries = new List<SelectListItem>
    {
        new SelectListItem { Text = "USA", Value = "USA" },
        new SelectListItem { Text = "Germany", Value = "Germany" },
        new SelectListItem { Text = "UK", Value = "UK" },
        new SelectListItem { Text = "Japan", Value = "Japan" },
        new SelectListItem { Text = "Australia", Value = "Australia" }
    };
    
    public async Task<IActionResult> OnPostAsync()
    {
        
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var userExists = await _userRepository.GetUserByEmailAsync(Input.Email);
        if (userExists != null)
        {
            ModelState.AddModelError("Input.Email", "Email already in use.");
            return Page();
        }

        var user = _mapper.Map<User>(Input);

        await _userRepository.CreateUserAsync(user);
        
        return RedirectToPage("/Account/Login");
    }
}