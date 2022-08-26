using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibraryModels
{
    public class Employee_Project
    {

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }


        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
