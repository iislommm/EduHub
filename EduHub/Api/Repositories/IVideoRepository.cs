using Domain.Entities;

namespace Application.Repositories;

public interface IVideoRepository
{
    Task<long> InsertAsync(Video video);
    Task UpdateAsync(Video video);
    Task DeleteAsync(long videoId);
    Task<IEnumerable<Video>> SelectVideosByPriceAsync(decimal price);
    Task<Video?> SelectByIdAsync(long videoId);
    Task<Video?> SelectByNameAsync(string name);
    Task<IEnumerable<Video>> SelectAllAsync();

    Task<IEnumerable<Video>> SelectByCategoryIdAsync(long categoryId);
    Task<IEnumerable<Video>> SelectByInstructorIdAsync(int instructorId);

    Task<IEnumerable<Video>> SelectWithCategoryAsync();         
    Task<IEnumerable<Video>> SelectWithInstructorAsync();       

    Task IncrementViewsAsync(long videoId);                  
    Task<IEnumerable<Video>> SelectVideosBetweemPriceAsyncn(decimal minPrice, decimal maxPrice);        
}
