using System.ComponentModel.DataAnnotations;

namespace Gadara2.Models.Entities
{
    public class Projects
    {
        [Key]
        public int ProjectsId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public List<Taskk> taskks { get; set; }
    }
}
