using aysconsultores.dotnet_azure_function.Entities;

namespace aysconsultores.dotnet_azure_function.Contracts;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<User> EditAsync(User user);
    Task<bool> RemoveAsync(User user);
    Task<User> GetSingleAsync(string value);
    Task<IEnumerable<User>> GetAllAsync();
    Task<bool> CheckIfExistsAsync(int userId);
    Task<User> AuthenticateAsync(string username, string password);
}