using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Core.Errors;

namespace Infrastructure.Persistance.Repositories;

public class CommentRepository(AppDbContextMS context) : ICommentRepository
{
    public async Task<long> InsertAsync(Comment comment)
    {
        await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
        return comment.CommentId;
    }

    public async Task DeleteAsync(long commentId)
    {
        var comment = await context.Comments.FindAsync(commentId);
        if (comment is null)
            throw new NotFoundException("Comment not found");

        context.Comments.Remove(comment);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Comment>> SelectByVideoIdAsync(long videoId)
    {
        return await context.Comments
            .Where(c => c.VideoId == videoId)
            .Include(c => c.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<Comment>> SelectByUserIdAsync(long userId)
    {
        return await context.Comments
            .Where(c => c.UserId == userId)
            .Include(c => c.Video)
            .ToListAsync();
    }

    public async Task<Comment?> SelectByIdAsync(long commentId)
    {
        return await context.Comments
            .Include(c => c.User)
            .Include(c => c.Video)
            .FirstOrDefaultAsync(c => c.CommentId == commentId);
    }
}
