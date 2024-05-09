using Car_Rental.Models;

namespace Car_Rental.Services;

public interface IAuthenticationService
{
    Task<bool> SignInAsync(string email, string password);
    Task RefreshUserClaimsAsync(User user);
    Task SignOutAsync();
}