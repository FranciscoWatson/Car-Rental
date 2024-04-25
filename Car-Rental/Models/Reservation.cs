using System.ComponentModel.DataAnnotations.Schema;
using Car_Rental.Enums;

namespace Car_Rental.Models;

public class Reservation
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReservationId { get; set; }
    public int CarId { get; set; }
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    
    public Car Car { get; set; }
    public User User { get; set; }
    
}