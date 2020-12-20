using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerLookup.Models.Dto
{
    public class CustomerDto
    {
        [StringLength(21)]
        [Required]
        public string Id { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        [StringLength(6)]
        public string Branch { get; set; }
        [StringLength(16)]
        public string Banker { get; set; }
        [StringLength(5)]
        public string Status { get; set; }

        [StringLength(74)]
        public string Segment { get; set; }

        [StringLength(5)]
        public string BankId { get; set; }
        
        public DateTime BirthDate { get; set; }
        public DateTime LastContact { get; set; }

        [StringLength(4)]
        public string SGFN { get; set; }

        [StringLength(35)]
        public string Kundenattrakt { get; set; }

        [StringLength(35)]
        public string Betreuintens { get; set; }
        
        public DateTime NextContact { get; set; }

        [StringLength(16)]
        public string KST { get; set; }
        



    }

    //[]
    //  ,[]
    //  ,[]
    //  ,[]
    //  ,[]
    //  ,[]
    //  ,[]
    //  ,[]
    //  ,[]
    //  ,[]
    //  ,[]
    //  ,[]
    //  ,[]
    //  ,[]
}
