using System.ComponentModel.DataAnnotations;

namespace restApiProject.Data.ViewModels
{
    public class EditUser
    {
        public int Id { get; set; }
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


    }
}
