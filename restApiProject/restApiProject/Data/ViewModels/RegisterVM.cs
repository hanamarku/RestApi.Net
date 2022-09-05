using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restApiProject.Data.ViewModels
{
    public class RegisterVM
    {

        [Display(Name = "Name")]
        //[Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "LastName")]
        //[Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        //[Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Display(Name = "Username")]
        //[Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        //[Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[StringLength(500)]
        //public string ImageUrl { get; set; } = String.Empty;

        ////[Required]
        [NotMapped]
        public IFormFile ProfileImage { get; set; }

        //[Display(Name = "Confirm password")]
        //[Required(ErrorMessage = "Confirm password is required")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Passwords do not match")]
        //public string ConfirmPassword { get; set; }
    }
}
