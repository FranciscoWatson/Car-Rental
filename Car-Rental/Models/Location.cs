using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental.Models;

public class Location
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LocationId { get; set; }
    
    [MaxLength(50)]
    public string City { get; set; }

    [MaxLength(50)]
    public string Country { get; set; }


}