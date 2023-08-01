using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Models
{
    public class Employee
    {
        [Key]
        public long RecordId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Project { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
