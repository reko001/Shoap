using Shoap.Api.Entities;

namespace Shoap.Api.Repositories.Contracts;

public interface IUserRepository
{
    Task<User?> GetUser(string login);
    Task InsertUser(User user);
    Task<int> GetNextId();
}
