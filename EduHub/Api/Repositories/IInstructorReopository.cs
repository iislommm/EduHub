using Domain.Entities;

namespace Application.Repositories;

public interface IInstructorRepository
{
    Task<long> InsertAsync(Instructor instructor);
    Task UpdateAsync(Instructor instructor);
    Task DeleteAsync(long instructorId);

    Task<Instructor?> SelectByIdAsync(long instructorId);
    Task<Instructor?> SelectByEmailAsync(string email);
    Task<IEnumerable<Instructor>> SelectAllAsync();
    Task<IEnumerable<Instructor>> SelectWithVideosAsync();
}
