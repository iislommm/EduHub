namespace Application.Mappers;

public static class LikeMapper
{
    public static Like ToEntity(LikeCreateDto dto)
    {
        return new Like
        {
            UserId = dto.UserId,
            VideoId = dto.VideoId,
            LikedAt = DateTime.UtcNow
        };
    }

    public static LikeDto ToDto(Like like)
    {
        return new LikeDto
        {
            Id = like.Id,
            UserFirstName = like.User.FirstName,
            LikedAt = like.LikedAt
        };
    }
}
