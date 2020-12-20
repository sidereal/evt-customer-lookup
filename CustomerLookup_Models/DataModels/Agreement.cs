using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerLookup.Models.DataModels
{
    public class Agreement
    {
        
        [StringLength(21)]
        [Required]
        public string AGREEMENT_ID { get; set; }

        [StringLength(21)]
        [Required]
        public string CUSTOMER_ID { get; set; }

        [StringLength(5)]
        public string BANK_ID { get; set; }

        [StringLength(16)]
        public string PRODUCT_ID { get; set; }

        public decimal AGRMT_BALANCE { get; set; }

        public DateTime AGRMT_OPEN_DATE  { get; set; }

        public DateTime AGRMT_CLOSE_DATE { get; set; }

        public decimal AGRMT_AMOUNT { get; set; }

        public DateTime LAST_PMNT_DATE { get; set; }
        public DateTime NEXT_PMNT_DATE { get; set; }

        [StringLength(10)]
        public string AGRMT_PMNT_TYPE { get; set; }

        public decimal AGRMT_LIMIT { get; set; }

        [StringLength(4)]
        public string AGRMT_ABW_OBJ_TYP_SCHL { get; set; }

        [StringLength(32)]
        public string AGRMT_ABW_OBJ_ID { get; set; }

        [StringLength(4)]
        public string AGRMT_ABW_OBJ_WHG_SCHL { get; set; }

        [StringLength(4)]
        public string AGRMT_STATUS { get; set; }

    }
}
