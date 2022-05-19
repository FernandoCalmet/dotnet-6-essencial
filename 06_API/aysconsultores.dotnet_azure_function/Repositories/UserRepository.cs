using aysconsultores.dotnet_azure_function.Contracts;
using aysconsultores.dotnet_azure_function.Entities;
using aysconsultores.dotnet_azure_function.Helpers;
using Microsoft.EntityFrameworkCore;

namespace aysconsultores.dotnet_azure_function.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApiDataContext _context;

    public UserRepository(ApiDataContext context)
    {
        _context = context;
    }

    public async Task<User> AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> EditAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> RemoveAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User> GetSingleAsync(string value)
    {
        bool isNumeric = int.TryParse(value, out int userId);
        if (isNumeric)
            return await _context.Users.FindAsync(userId);
        else
            return await _context.Users.Where(u => u.Email.Contains(value)).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<bool> CheckIfExistsAsync(int userId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId) != null;
    }

    public async Task<User> AuthenticateAsync(string username, string password)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == password);
    }
}
