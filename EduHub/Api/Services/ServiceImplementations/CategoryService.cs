using Application.Dtos;
using Application.Mappers;
using Application.Repositories;
using Core.Errors;
using Domain.Entities;

namespace Application.Services.ServiceImplementations;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<long> AddCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        var category = new Category()
        {
            Name = categoryCreateDto.Name,
        };

        return await categoryRepository.InsertCategoryAsync(category);
    }

    public async Task DeleteCategoryAsync(long? categoryId) ///////////////////////////////////////////////////////////////// ////////////////////////////
    {
        var category = await categoryRepository.SelectByIdAsync(categoryId.Value);
        if (categoryId is null) throw new NotFoundException($"category with this ID : {categoryId} not found");

        return await categoryRepository.DeleteAsync(category);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCatigoriesAsync()
    {
        var categories = await categoryRepository.SelectAllAsync();
        return categories.Select(CategoryMapper.ToCategoryDto).ToList();
    }

    public async Task<CategoryDto> GetCategoryByNameAsync(string categoryName)
    {
        var category = await categoryRepository.SelectCategoryByNameAsync(categoryName);
        return category
    }

    public async Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto, long? categoryId)
    {
        var category = await categoryRepository.SelectByIdAsync(categoryId.Value);
        if (categoryId is null) throw new NotFoundException($"Category with id : {categoryId} not found");
        else
        {
            categoryUpdateDto.CategoryName = category.Name;
        }
    }
}
