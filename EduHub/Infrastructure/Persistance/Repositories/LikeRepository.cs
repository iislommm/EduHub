using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Core.Errors;

namespace Infrastructure.Persistance.Repositories;

public class LikeRepository(AppDbContextMS context) : ILikeRepository
{
    public async Task<long> InsertAsync(Like like)
    {
        await context.Likes.AddAsync(like);
        await context.SaveChangesAsync();
        return like.Id;
    }

    public async Task DeleteAsync(long likeId)
    {
        var like = await context.Likes.FindAsync(likeId);
        if (like is null)
            throw new NotFoundException("Like not found");

        context.Likes.Remove(like);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Like>> SelectByVideoIdAsync(long videoId)
    {
        return await context.Likes
            .Where(l => l.VideoId == videoId)
            .Include(l => l.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<Like>> SelectByUserIdAsync(long userId)
    {
        return await context.Likes
            .Where(l => l.UserId == userId)
            .Include(l => l.Video)
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(long userId, long videoId)
    {
        return await context.Likes.AnyAsync(l => l.UserId == userId && l.VideoId == videoId);
    }
}
