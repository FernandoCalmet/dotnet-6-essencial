using aysconsultores.dotnet_web_api.Entities;

namespace aysconsultores.dotnet_web_api.Contracts;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<User> EditAsync(User user);
    Task<bool> RemoveAsync(int id);
    Task<User> GetSingleAsync(string value);
    Task<IEnumerable<User>> GetAllAsync();
    Task<bool> CheckIfExistsAsync(int id);
    Task<string> AuthenticateAsync(string username, string password);
}
