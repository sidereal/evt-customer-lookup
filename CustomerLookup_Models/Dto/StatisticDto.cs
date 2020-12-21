using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerLookup.Models.Dto
{
    public class StatisticDto
    {
        
        [Required]
        public decimal Id { get; set; }

        [Required]
        [StringLength(21)]
        public string CustomerId { get; set; }

        public decimal Year { get; set; }
        public decimal Month { get; set; }
        public decimal MaxAmount { get; set; }
        public DateTime DateMax { get; set; }
        public decimal SecAmount { get; set; }
        public DateTime DateSec { get; set; }
        public DateTime LastDate { get; set; }
        public DateTime FixedDate { get; set; }
        
        [Required]
        public decimal EventId { get; set; }
    }
}
