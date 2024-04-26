using System.ComponentModel.DataAnnotations;
namespace Car_Rental.Pages.InputModels;


public class RegisterInputModel
{
    [Required]
    
            [StringLength(50)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; } = string.Empty;
    
            [Required]
            [StringLength(50)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; } = string.Empty;
    
            [Required]
            [EmailAddress]
            [StringLength(255)]
            [Display(Name = "Email Address")]
            public string Email { get; set; } = string.Empty;
    
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; } = string.Empty;
    
            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; } = string.Empty;
    
            [Required]
            [StringLength(30)]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; } = string.Empty;
    
            [DataType(DataType.Date)]
            [Display(Name = "Date of Birth")]
            public DateTime? DateOfBirth { get; set; }
    
            [Required]
            [StringLength(100)]
            [Display(Name = "Address Line 1")]
            public string AddressOne { get; set; } = string.Empty;
    
            [StringLength(100)]
            [Display(Name = "Address Line 2")]
            public string? AddressTwo { get; set; }
    
            [Required]
            [StringLength(50)]
            [Display(Name = "City")]
            public string City { get; set; } = string.Empty;
    
            [Required]
            [StringLength(50)]
            [Display(Name = "Country")]
            public string Country { get; set; } = string.Empty;
    
            [Required]
            [StringLength(50)]
            [Display(Name = "Driver's License Number")]
            public string LicenseNumber { get; set; } = string.Empty;
}