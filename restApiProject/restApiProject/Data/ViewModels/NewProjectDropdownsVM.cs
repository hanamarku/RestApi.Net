using ClassLibraryModels;

namespace restApiProject.Data.ViewModels
{
    public class NewProjectDropdownsVM
    {
        public NewProjectDropdownsVM()
        {
            Employee = new List<User>();
        }
        public List<User> Employee { get; set; }
    }
}
