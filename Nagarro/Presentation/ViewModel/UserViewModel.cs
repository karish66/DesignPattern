using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Presentation.ViewModel
{
    public class UserViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Full Name :")]
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Display(Name = "User Name :")]
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Display(Name = "Password :")]
        [RegularExpression("(?=.*[*+\\/|!\"£$%^&*()#[\\]@~'?><,.=-_]).{5,}", ErrorMessage = "The password must be at least 5 characters and contain at least one special character.")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Display(Name = "Contact Number :")]
        [Required(ErrorMessage = "Contact Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string ContactNumber { get; set; }

        [Display(Name = "Email Id :")]
        [RegularExpression("[^@]+@[^@]+\\.[^@]+$", ErrorMessage = "Enter a valid Email Id.")]
        [Required(ErrorMessage = "Email is required")]
        public string EmailId { get; set; }
        
        
    }
}