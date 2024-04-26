using System.ComponentModel.DataAnnotations;

namespace Car_Rental.Pages.InputModels;

public class LoginInputModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}