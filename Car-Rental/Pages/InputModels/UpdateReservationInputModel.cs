using System.ComponentModel.DataAnnotations;

namespace Car_Rental.Pages.InputModels;

public class UpdateReservationInputModel
{
    [Required]
    public int ReservationId { get; set; }
    [Required]
    public int CarId { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }

}