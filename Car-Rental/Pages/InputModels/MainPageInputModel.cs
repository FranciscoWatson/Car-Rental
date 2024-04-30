using System.ComponentModel.DataAnnotations;

namespace Car_Rental.Pages.InputModels;

public class MainPageInputModel
{
    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "Country is required.")]
    public string Country { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }
}