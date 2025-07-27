using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class RoleRepository(AppDbContextPS appDbContext) : IRoleRepository
{
    private readonly AppDbContextPS _context = appDbContext;

    public async Task<long> InsertUserRoleAsync(Role userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
        await _context.SaveChangesAsync();
        return userRole.RoleId;
    }

    public async Task DeleteUserRoleAsync(Role userRole)
    {
        _context.UserRoles.Remove(userRole);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Role>> SelectAllRolesAsync()
    {
        return await _context.UserRoles.ToListAsync();
    }

    public async Task<ICollection<User>> SelectAllUsersByRoleNameAsync(string roleName)
    {
        return await _context.Users
            .Where(u => u.Role != null && u.Role.Name.ToLower() == roleName.ToLower())
            .ToListAsync();
    }

    public async Task<Role?> SelectUserRoleByIdAsync(long userRoleId)
    {
        return await _context.UserRoles.FindAsync(userRoleId);
    }

    public async Task<Role?> SelectUserRoleByRoleName(string userRoleName)
    {
        return await _context.UserRoles
            .FirstOrDefaultAsync(r => r.Name.ToLower() == userRoleName.ToLower());
    }

    public async Task UpdateUserRoleAsync(Role userRole)
    {
        _context.UserRoles.Update(userRole);
        await _context.SaveChangesAsync();
    }
}
