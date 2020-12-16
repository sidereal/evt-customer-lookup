using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerLookup.Models.DataModels
{
    public class Txn
    {
        [StringLength(40)]
        [Required]
        public string TXN_ID { get; set; }

        [StringLength(21)]
        [Required]
        public string AGREEMENT_ID { get; set; }

        [StringLength(21)]
        [Required]
        public string CUSTOMER_ID { get; set; }
       

        [StringLength(5)]
        public string BANK_ID { get; set; }

        [StringLength(11)]
        public string TXN_CODE { get; set; }
        
        public DateTime TXN_DATE { get; set; }

        public decimal TXN_AMOUNT { get; set; }
        
        [StringLength(200)]
        public string TXN_TEXT { get; set; }

        [StringLength(3)]
        public string CURRENCY_CODE { get; set; }
        
        public decimal TXN_CUR_AMOUNT { get; set; }

        [StringLength(40)]
        public string TXN_CORR_ACCOUNT { get; set; }

        [StringLength(200)]
        public string TXN_CORR_NAME { get; set; }

        [StringLength(11)]
        public string TXN_CORR_BANK { get; set; }

        [StringLength(2)]
        public string TXN_CORR_COUNTRY { get; set; }

        [StringLength(74)]
        public string CUSTOMER_SEGMENT { get; set; }

        [StringLength(20)]
        public string CUSTOMER_TYPE { get; set; }

        [StringLength(1)]
        public string SALARY_FLAG { get; set; }

        [StringLength(16)]
        public string PRODUCT_ID { get; set; }

    }
}
