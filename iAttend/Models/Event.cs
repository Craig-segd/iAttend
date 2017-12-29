using System.ComponentModel.DataAnnotations;

namespace iAttend.Models
{
    public class Event
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

    }
}