using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iAttend.Models
{
    public class Attendee
    {

        public int Id { get; set; }

        public ApplicationUser Name { get; set; }

        [Required]
        public string _Name { get; set; }

        [Required]
        public Guid userId { get; set; }

        //public string NameId { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [StringLength(100)]
        public string Company { get; set; }

        public Event Event { get; set; }

        public byte EventId { get; set; }

        public string EventName { get; set; }

        [Required]
        [DefaultValue(0)]
        public int Attended { get; set; }



    }
}