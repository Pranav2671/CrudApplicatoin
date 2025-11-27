using System.ComponentModel.DataAnnotations;

namespace CrudApplicatoin.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullName { get; set; }

        public String? City { get; set; }

        public string? State { get; set; }

        public decimal Salary { get; set; }
    }
}
