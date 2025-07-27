using Domain.Entities;

namespace Application.Mappers;

public static class VideoMapper
{
    public static Video ToEntity(VideoCreateDto dto)
    {
        return new Video
        {
            Name = dto.Name,
            Description = dto.Description,
            MB = dto.MB,
            Price = dto.Price,
            Views = dto.Views,
            Duration = dto.Duration,
            VideoUrl = dto.VideoUrl,
            CategoryId = dto.CategoryId,
            InstructorId = dto.InstructorId
        };
    }

    public static VideoDto ToDto(Video video)
    {
        return new VideoDto
        {
            VideoId = video.VideoId,
            Name = video.Name,
            Description = video.Description,
            MB = video.MB,
            Price = video.Price,
            Views = video.Views,
            Duration = video.Duration,
            VideoUrl = video.VideoUrl,
            CategoryId = video.CategoryId,
            InstructorId = video.InstructorId
        };
    }

    public static void UpdateEntity(Video video, VideoUpdateDto dto)
    {
        video.Name = dto.Name;
        video.Description = dto.Description;
        video.MB = dto.MB;
        video.Price = dto.Price;
        video.Duration = dto.Duration;
        video.VideoUrl = dto.VideoUrl;
        // Views va CategoryId, InstructorId odatda update qilinmaydi
    }
}
