using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibraryModels
{
    public class User : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }


        [StringLength(500)]
        public string ImageUrl { get; set; } = String.Empty;

        [NotMapped]
        public IFormFile ProfileImage { get; set; } = null;
        public virtual List<Project>? Projects { get; set; }
        public virtual List<Taskk>? Tasks { get; set; }
    }

    //public class Employee 
    //{
    //    [Key]
    //    [ForeignKey("Id")]
    //    public int Id { get; set; }
    //    public virtual User user { get; set; }

    //    [StringLength(500)]
    //    public string ImageUrl { get; set; }

    //    //[Required]
    //    [NotMapped]
    //    public IFormFile ProfileImage { get; set; }
    //    public int ProjectId { get; set; }
    //    [ForeignKey("ProjectId")]
    //    public virtual List<Project> Projects { get; set; }
    //    public virtual List<Taskk>? Tasks { get; set; }
    //}
}
