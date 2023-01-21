namespace Shoap.Services.Contracts;

public interface IContextService
{
    int? UserId { get; set;  }
    string? UserName { get; set; }
}
