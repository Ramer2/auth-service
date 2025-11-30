using AuthService.Models.Models;

namespace AuthService.Services.DTOs;

public class UserDTO
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string HashedPassword { get; set; }
    public string CreatedAt  { get; set; }
    public bool? IsActive { get; set; }

    public List<RoleDto> Roles { get; set; } = new();
    
    public List<PermissionDto> Permissions{ get; set; } = new();
}