using Application.Abstractions.Services;
using Application.Repositories;

namespace Application.Services;

//public class LikeService(
//    ILikeRepository likeRepository,
//    IMapper mapper) : ILikeService
//{
//=-098654302{
//    public async Task<long> AddLikeAsync(LikeCreateDto dto)
//    {
//        bool exists = await likeRepository.ExistsAsync(dto.UserId, dto.VideoId);
//        if (exists)
//            throw new ConflictException("User has already liked this video");

//        var like = mapper.Map<Like>(dto);
//        like.LikedAt = DateTime.UtcNow;

//        return await likeRepository.InsertAsync(like);
//    }

//    public async Task RemoveLikeAsync(long likeId)
//    {
//        await likeRepository.DeleteAsync(likeId);
//    }

//    public async Task<IEnumerable<LikeDto>> GetLikesByVideoIdAsync(long videoId)
//    {
//        var likes = await likeRepository.SelectByVideoIdAsync(videoId);
//        return mapper.Map<IEnumerable<LikeDto>>(likes);
//    }

//    public async Task<IEnumerable<LikeDto>> GetLikesByUserIdAsync(long userId)
//    {
//        var likes = await likeRepository.SelectByUserIdAsync(userId);
//        return mapper.Map<IEnumerable<LikeDto>>(likes);
//    }

//    public async Task<bool> HasUserLikedAsync(long userId, long videoId)
//    {
//        return await likeRepository.ExistsAsync(userId, videoId);
//    }
//}
