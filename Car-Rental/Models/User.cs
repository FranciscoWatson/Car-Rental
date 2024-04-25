using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental.Models;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [MaxLength(50)] 
    public string FirstName { get; set; }

    [MaxLength(50)] 
    public string LastName { get; set; }

    [MaxLength(255)]
    [Column(TypeName = "varchar(255)")]
    [EmailAddress]
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    [MaxLength(30)]
    [Column(TypeName = "varchar(30)")]
    public string PhoneNumber { get; set; }
    
    public DateTime? DateOfBirth { get; set; }
    
    [MaxLength(100)]
    public string AddressOne { get; set; }
    
    [MaxLength(100)]
    public string? AddressTwo { get; set; }
    
    [MaxLength(50)]
    public string City { get; set; }
    
    [MaxLength(50)]
    public string Country { get; set; }
    
    [MaxLength(50)]
    public string LicenseNumber { get; set; }
}