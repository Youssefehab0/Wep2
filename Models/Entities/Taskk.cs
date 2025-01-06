using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gadara2.Models.Entities
{
    public class Taskk
    {
        [Key]
        public int TaskkId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
        [Required]
        public string status { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Projects Projects { get; set; }
    }
}
