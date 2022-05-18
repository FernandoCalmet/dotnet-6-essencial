using aysconsultores.dotnet_web_api.Contracts;
using aysconsultores.dotnet_web_api.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace aysconsultores.dotnet_web_api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<User> AddAsync(User user)
    {
        var userToCreate = new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Password = user.Password,
            Email = user.Email,
            Gender = user.Gender
        };
        return await _userRepository.AddAsync(userToCreate);
    }

    public async Task<User> EditAsync(User user)
    {
        var userToUpdate = await _userRepository.GetSingleAsync(user.Id.ToString());
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        return await _userRepository.EditAsync(userToUpdate);
    }

    public async Task<bool> RemoveAsync(User user)
    {
        var userToDelete = _userRepository.GetSingleAsync(user.Id.ToString());
        return await _userRepository.RemoveAsync(userToDelete.Result);
    }

    public async Task<User> GetSingleAsync(string value)
    {
        return await _userRepository.GetSingleAsync(value);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<bool> CheckIfExistsAsync(int userId)
    {
        return await _userRepository.CheckIfExistsAsync(userId);
    }

    public async Task<string> AuthenticateAsync(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            throw new Exception("Username or password is empty");

        var user = await _userRepository.AuthenticateAsync(username, password);

        if (user == null)
            throw new Exception("Username or password is incorrect");

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fjurkbdlhmklqacwqzdxmkkhvqoclyqz"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokenOptions = new JwtSecurityToken(
            issuer: "https://localhost:7044",
            audience: "https://localhost:7044",
            claims: new List<Claim>(),
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: signinCredentials);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return tokenString;
    }
}
