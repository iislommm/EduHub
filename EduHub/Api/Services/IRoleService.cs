using Application.Dtos;

namespace Application.Services;

public interface IRoleService
{
    Task<long> AddUserAsync(RoleCreateDto roleCreateDto, string roleName);
    Task<IEnumerable<RoleDto>> GetAllUsersAsync();
    Task<IEnumerable<RoleDto>> GetAllUsersByRolesNameAsync(string roleName);
    Task DeleteRoleAsync(string deletingRole, string roleName);
    Task UpdateRoleAsync(RoleUpdateDto roleUpdateDto);
}
