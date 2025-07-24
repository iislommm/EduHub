using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> SelectUserByIdAsync(long id);
    Task<User?> SelectUserByUserNameAsync(string userName);

    Task<List<User>> GetAllAsync();
    Task<long> InsertUserAsync(User user);
    Task UpdateUserRoleAsync(long userId, long userRoleId);
    Task DeleteUserById(long userId);
 
}
