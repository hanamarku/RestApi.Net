namespace restApiProject.Data.ViewModels
{
    public class NewTaskVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
    }
}
