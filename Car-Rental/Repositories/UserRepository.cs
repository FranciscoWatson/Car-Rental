using Car_Rental.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CarRentalDbContext _carRentalDbContext;

    public UserRepository(CarRentalDbContext carRentalDbContext)
    {
        _carRentalDbContext = carRentalDbContext;
    }
    
    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _carRentalDbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _carRentalDbContext.Users.ToListAsync();
    }

    public async Task CreateUserAsync(User user)
    {
        await _carRentalDbContext.Users.AddAsync(user);
        await _carRentalDbContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _carRentalDbContext.Users.Update(user);
        await _carRentalDbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _carRentalDbContext.Users.FindAsync(userId);
        if (user != null)
        {
            _carRentalDbContext.Users.Remove(user);
            await _carRentalDbContext.SaveChangesAsync();
        }
    }
}