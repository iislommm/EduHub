namespace Application.Services;

public interface IVideoService
{
    Task<long> AddVideoAsync(VideoCreateDto dto);
    Task DeleteVideoAsync(long videoId);
    Task UpdateVideoasync(long videoId, VideoUpdateDto dto);
    Task<VideoGetDto> GetVideoByIdAsync(long videoId);
    Task<IEnumerable<VideoGetDto>> GetAllVideosAsync();
    Task<IEnumerable<VideoGetDto>> GetVideosByInstructorAsync(long instructorId);
    Task<IEnumerable<VideoGetDto>> GetVideosByCateforyIdAsync(long categoryid);
}
