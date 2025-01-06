using System.ComponentModel.DataAnnotations;

namespace Gadara2.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(50)]
        public string? Role { get; set; }
        public List<Taskk> taskks { get; set; }
    }
}
