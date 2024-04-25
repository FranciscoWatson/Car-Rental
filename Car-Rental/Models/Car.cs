using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental.Models;

public class Car
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CarId { get; set; }
    
    [MaxLength(50)] 
    public string Make { get; set; }
    
    [MaxLength(50)] 
    public string Model { get; set; }
    
    public int Year { get; set; }
    
    [MaxLength(50)] 
    public string LicensePlate { get; set; }
    
    public List<Reservation> Reservations { get; set; }
    
    
    public int LocationId { get; set; }
    public Location Location { get; set; }

}