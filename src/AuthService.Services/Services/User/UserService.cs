using AuthService.DAL;
using AuthService.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Services.Services.User;

public class UserService : IUserService
{
    private readonly CredentialsDatabaseContext _context;

    public UserService(CredentialsDatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<UserDTO>> GetUsers()
    {
        var users = await _context.Users
            .Include(u => u.Roles)
            .Include(u => u.Permissions)
            .ToListAsync();

        var userDtos = new List<UserDTO>();
        
        foreach (var user in users)
        {
            var newUser = new UserDTO
            {
                UserId = user.UserId.ToString(),
                Username = user.Username,
                Email = user.Email,
                HashedPassword = user.HashedPassword.ToString(),
                CreatedAt = user.CreatedAt.ToString(),
                IsActive = user.IsActive
            };

            foreach (var role in user.Roles)
            {
                newUser.Roles.Add(new RoleDto
                {
                    RoleId = role.RoleId.ToString(),
                    RoleName = role.RoleName
                });
            }

            foreach (var permission in user.Permissions)
            {
                newUser.Permissions.Add(new PermissionDto 
                {
                    PermissionId = permission.PermissionId.ToString(),
                    PermissionName = permission.PermissionName 
                });
            }
            
            userDtos.Add(newUser);
        }
        
        return userDtos;
    }
}