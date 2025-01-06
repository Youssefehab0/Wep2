using Gadara2.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gadara2.ViewModels
{
    public class Taskviewmodel
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
        public List<User> User { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public List<Projects> Projects { get; set; }
    }
}
