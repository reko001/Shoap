using Shoap.Services.Contracts;

namespace Shoap.Services;

public class ContextService : IContextService
{
    public int? UserId { get; set; }
    public string? UserName { get; set; }
}
