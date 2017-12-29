using iAttend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iAttend.ViewModels
{
    public class AttendeeFormModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        [DefaultValue(0)]
        public int Attended { get; set; }

        [Required]
        public byte Event { get; set; }

        public string EventName { get; set; }

        public IEnumerable<Event> Events { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date}").Date;

        }
    }
}