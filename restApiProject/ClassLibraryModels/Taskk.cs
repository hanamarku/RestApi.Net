using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibraryModels
{
    public class Taskk : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCreated { get; set; }
        public int? Projectid { get; set; }
        [ForeignKey("Projectid")]
        public virtual Project project { get; set; }
        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual User Employee { get; set; }
    }
}
