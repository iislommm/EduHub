using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class RoleMapper
{
    public static Role ToEntity(RoleCreateDto dto)
    {
        return new Role
        {
            Name = dto.Name,
            Description = dto.Description
        };
    }

    public static RoleDto ToDto(Role role)
    {
        return new RoleDto
        {
            RoleId = role.RoleId,
            Name = role.Name,
            Description = role.Description
        };
    }

    public static void UpdateEntity(Role role, RoleUpdateDto dto)
    {
        role.Name = dto.Name;
        role.Description = dto.Description;
    }
}
