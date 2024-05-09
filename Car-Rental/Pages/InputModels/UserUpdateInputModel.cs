using System.ComponentModel.DataAnnotations;

namespace Car_Rental.Pages.InputModels;

public class UserUpdateInputModel
{
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(30)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
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