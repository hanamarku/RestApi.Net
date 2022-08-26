using System.ComponentModel.DataAnnotations;

namespace restApiProject.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Usernmae is required")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
