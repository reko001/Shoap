using System.ComponentModel.DataAnnotations;

namespace Shoap.Pages;

public class SignUpModel
{
    [Required]
    [StringLength(30, ErrorMessage = "Login is too long, max 30 characters")]
    public string? Login { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "Password is too long, max 30 characters")]
    public string? Password { get; set; }

    public string ErrorMessage = string.Empty;
}
