using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Core.Errors;

namespace Infrastructure.Persistance.Repositories;

public class InstructorRepository(AppDbContextMS context) : IInstructorRepository
{
    public async Task<long> InsertAsync(Instructor instructor)
    {
        await context.Instructors.AddAsync(instructor);
        await context.SaveChangesAsync();
        return instructor.InstructorId;
    }

    public async Task UpdateAsync(Instructor instructor)
    {
        var existing = await context.Instructors.FindAsync(instructor.InstructorId);
        if (existing is null)
            throw new NotFoundException("Instructor not found");

        existing.FullName = instructor.FullName;
        existing.Email = instructor.Email;
        existing.Bio = instructor.Bio;
        existing.ProfileImageUrl = instructor.ProfileImageUrl;
        existing.SocialLink = instructor.SocialLink;
        existing.UserId = instructor.UserId;

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long instructorId)
    {
        var instructor = await context.Instructors.FindAsync(instructorId);
        if (instructor is null)
            throw new NotFoundException("Instructor not found");

        context.Instructors.Remove(instructor);
        await context.SaveChangesAsync();
    }

    public async Task<Instructor?> SelectByIdAsync(long instructorId)
    {
        return await context.Instructors.FindAsync(instructorId);
    }

    public async Task<Instructor?> SelectByEmailAsync(string email)
    {
        return await context.Instructors
            .FirstOrDefaultAsync(i => i.Email.ToLower() == email.ToLower());
    }

    public async Task<IEnumerable<Instructor>> SelectAllAsync()
    {
        return await context.Instructors.ToListAsync();
    }

    public async Task<IEnumerable<Instructor>> SelectWithVideosAsync()
    {
        return await context.Instructors
            .Include(i => i.Videos)
            .ToListAsync();
    }
}
