using System.ComponentModel.DataAnnotations;

namespace ClassLibraryModels
{
    public class Project : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public virtual List<Taskk>? Tasks { get; set; }
        public virtual List<Employee>? Employees { get; set; }
    }
}
