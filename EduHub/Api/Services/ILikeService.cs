namespace Application.Abstractions.Services;

public interface ILikeService
{
    Task<long> AddLikeAsync(LikeCreateDto dto);
    Task DeleteLikeAsync(long likeId);
    Task<IEnumerable<LikeDto>> GetLikesByVideoIdAsync(long videoId);
    Task<IEnumerable<LikeDto>> GetLikesByUserIdAsync(long userId);
    Task<bool> HasUserLikedAsync(long userId, long videoId);
}
