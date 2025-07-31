using Domain.Entities;

namespace Application.Repositories;

public interface ILikeRepository
{
    Task<long> InsertAsync(Like like);
    Task DeleteAsync(long likeId);
    Task<IEnumerable<Like>> SelectByVideoIdAsync(long videoId);
    Task<IEnumerable<Like>> SelectByUserIdAsync(long userId);
    Task<Like> SelectLikeByIdAsync(long likeId);
    Task<bool> ExistsAsync(long userId, long videoId);
}
