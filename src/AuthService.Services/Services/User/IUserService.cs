using AuthService.Services.DTOs;

namespace AuthService.Services.Services.User;

public interface IUserService
{
    public Task<List<UserDTO>> GetUsers();
}