namespace WebApplication1.Models
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Sex { get; set; } 
        public int Year { get; set; }
        public int DeptId { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }

        public List<Dept> DeptList { get; set; } 
    }
}
