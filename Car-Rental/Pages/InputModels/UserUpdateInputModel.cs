using System.ComponentModel.DataAnnotations;

namespace Car_Rental.Pages.InputModels;

public class UserUpdateInputModel
{

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    

}