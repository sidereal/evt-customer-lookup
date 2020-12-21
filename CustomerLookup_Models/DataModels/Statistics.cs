using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerLookup.Models.DataModels
{
    public class Statistics
    {
        
        [Required]
        public decimal STATS_ID { get; set; }

        [Required]
        [StringLength(21)]
        public string CUSTOMER_ID { get; set; }

        public decimal YEAR_ { get; set; }
        public decimal MONTH_ { get; set; }
        public decimal MAX_AMOUNT { get; set; }
        public DateTime DATE_MAX { get; set; }
        public decimal SEC_AMOUNT { get; set; }
        public DateTime DATE_SEC { get; set; }
        public DateTime LAST_DATE { get; set; }
        public DateTime FIXED_DATE { get; set; }
        [Required]
        public decimal EVENT_ID { get; set; }
    }
}
