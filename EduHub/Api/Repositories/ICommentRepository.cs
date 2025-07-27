using Domain.Entities;

namespace Application.Repositories;

public interface ICommentRepository
{
    Task<long> InsertAsync(Comment comment);
    Task DeleteAsync(long commentId);
    Task<IEnumerable<Comment>> SelectByVideoIdAsync(long videoId);
    Task<IEnumerable<Comment>> SelectByUserIdAsync(long userId);
    Task<Comment?> SelectByIdAsync(long commentId);
}
