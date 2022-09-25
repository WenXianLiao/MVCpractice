using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="請輸入姓名")]
        public string Name { get; set; } 
        [Required(ErrorMessage = "請選擇性別")]
        public string Sex { get; set; } 
        [Required(ErrorMessage = "請輸入年紀")]
        [RegularExpression("[0-9]*",ErrorMessage ="請輸入數字")]
        public int Year { get; set; }
        [Required(ErrorMessage = "請選擇部門")]
        public int DeptId { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }

        //public virtual Dept Dept { get; set; } 
    }
}
