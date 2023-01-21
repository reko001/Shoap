using Shoap.Models.Dtos;

namespace Shoap.Services.Contracts;

public interface IContextService
{
    UserDto? User { get; }

    void AddUser(UserDto user);
}
