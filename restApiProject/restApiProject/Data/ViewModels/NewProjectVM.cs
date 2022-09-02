using System.ComponentModel.DataAnnotations;

namespace restApiProject.Data.ViewModels
{
    public class NewProjectVM
    {
        [Display(Name = "Project name")]
        //[Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        //Relationships
        [Display(Name = "Select employees(s)")]
        //[Required(ErrorMessage = "required")]
        public List<int> EmployeesIds { get; set; }
    }
}
