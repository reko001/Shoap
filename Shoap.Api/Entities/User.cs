using System.ComponentModel.DataAnnotations.Schema;

namespace Shoap.Api.Entities;

[Table("users")]
public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public decimal Money { get; set; }
}
