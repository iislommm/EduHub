using Application.Dtos.Comment;
using Domain.Entities;

namespace Application.Mappers;

public static class CommentMapper
{
    public static Comment ToEntity(CommentCreateDto dto)
    {
        return new Comment
        {
            UserId = dto.UserId,
            VideoId = dto.VideoId,
            Text = dto.Text,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static CommentDto ToDto(Comment comment)
    {
        return new CommentDto
        {
            Id = comment.UserId,
            UserFirstName = comment.User.FirstName,
            Text = comment.Text,
            CreatedAt = comment.CreatedAt
        };
    }
}
