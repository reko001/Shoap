using Shoap.Models.Dtos;
using Shoap.Services.Contracts;

namespace Shoap.Services;

public class ContextService : IContextService
{
    public UserDto? User { get; private set; }

    public void AddUser(UserDto user)
    {
        User = user;
    }
}
