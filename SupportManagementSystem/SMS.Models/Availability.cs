namespace SMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Availability
    {
        public int Id { get; set; }

        [Required]
        public string AvailabilityName { get; set; }
    }
}
