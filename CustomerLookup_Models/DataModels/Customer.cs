using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerLookup.Models.DataModels
{
    public class Customer
    {
        [StringLength(21)]
        [Required]
        public string CUSTOMER_ID { get; set; }

        [StringLength(20)]
        public string CUSTOMER_TYPE { get; set; }

        [StringLength(6)]
        public string CUSTOMER_BRANCH { get; set; }
        [StringLength(16)]
        public string CUSTOMER_BANKER { get; set; }
        [StringLength(5)]
        public string CUSTOMER_STATUS { get; set; }

        [StringLength(74)]
        public string CUSTOMER_SEGMENT { get; set; }

        [StringLength(5)]
        public string BANK_ID { get; set; }
        
        public DateTime CUST_BIRTH_DATE { get; set; }
        public DateTime CUSTOMER_LAST_CONTACT { get; set; }

        [StringLength(4)]
        public string CUSTOMER_SGFN { get; set; }

        [StringLength(35)]
        public string CUSTOMER_KUNDENATTRAKT { get; set; }

        [StringLength(35)]
        public string CUSTOMER_BETREUINTENS { get; set; }
        
        public DateTime CUSTOMER_NEXT_CONTACT { get; set; }

        [StringLength(16)]
        public string CUSTOMER_KST { get; set; }
        



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
