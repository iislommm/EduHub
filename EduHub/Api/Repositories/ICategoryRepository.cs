using Domain.Entities;

namespace Application.Repositories;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(long id);
    Task<Category?> GetByNameAsync(string name);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<IEnumerable<Category>> GetWithVideosAsync();
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(long id);

}
    