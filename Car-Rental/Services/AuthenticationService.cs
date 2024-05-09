using System.Security.Claims;
using Car_Rental.Models;
using Car_Rental.Repositories;
using Microsoft.AspNetCore.Authentication;

namespace Car_Rental.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public AuthenticationService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<bool> SignInAsync(string email, string password)
    {
        var user = await _userRepository.Get(email, password);
        if (user == null) return false;

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        await _httpContextAccessor.HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

        return true;
    }

    public async Task SignOutAsync()
    {
        await _httpContextAccessor.HttpContext.SignOutAsync("MyCookieAuth");
    }

    public async Task RefreshUserClaimsAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        await SignOutAsync();
        await _httpContextAccessor.HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
    }

}