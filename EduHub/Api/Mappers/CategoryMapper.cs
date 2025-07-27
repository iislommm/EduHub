using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class CategoryMapper
{
    public static Category ToEntity(CategoryCreateDto dto)
    {
        return new Category
        {
            Name = dto.Name,
            IconUrl = dto.IconUrl,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static CategoryDto ToDto(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            IconUrl = category.IconUrl,
            CreatedAt = category.CreatedAt
        };
    }
}
