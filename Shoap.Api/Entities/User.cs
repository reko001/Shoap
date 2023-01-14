using System.ComponentModel.DataAnnotations.Schema;

namespace Shoap.Api.Entities;

[Table("users")]
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}
