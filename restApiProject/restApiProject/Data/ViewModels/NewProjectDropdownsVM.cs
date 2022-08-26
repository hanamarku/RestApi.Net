using ClassLibraryModels;

namespace restApiProject.Data.ViewModels
{
    public class NewProjectDropdownsVM
    {
        public NewProjectDropdownsVM()
        {
            Employee = new List<Employee>();
        }
        public List<Employee> Employee { get; set; }
    }
}
