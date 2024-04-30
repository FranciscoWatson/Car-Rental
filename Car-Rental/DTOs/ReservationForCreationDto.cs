using Car_Rental.Enums;

namespace Car_Rental.DTOs;

public class ReservationForCreationDto
{
    public int CarId { get; set; }
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    
}