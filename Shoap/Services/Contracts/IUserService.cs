using Shoap.Models.Dtos;

namespace Shoap.Services.Contracts;

public interface IUserService
{
    Task<UserDto?> GetUser(string login);
    Task InsertUser(string login, string password);
}
