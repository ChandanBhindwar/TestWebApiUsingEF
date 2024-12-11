using System.ComponentModel.DataAnnotations;

namespace TestWebApiUsingEF.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Salary { get; set; }
        public string? Designation { get; set; }
    }
}
