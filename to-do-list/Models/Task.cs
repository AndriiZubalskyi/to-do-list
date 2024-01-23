using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace to_do_list.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        [AllowNull]
        public DateTime? Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}
