namespace Car_Rental.DTOs;

public class ReservationDto
{
    public int ReservationId { get; set; }
    public string CarModel { get; set; }
    public string Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
}