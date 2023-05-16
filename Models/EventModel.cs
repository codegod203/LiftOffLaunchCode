using System;
using System.ComponentModel.DataAnnotations;

namespace Moonwalkers.Models
{
    public class EventModel
    {
        [Key]
        public int EventId { get; set; } // New property

        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
