using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerLookup.Models.Dto
{
    public class TxnDto
    {
        [StringLength(40)]
        [Required]
        public string Id { get; set; }

        [StringLength(21)]
        [Required]
        public string AgreementId { get; set; }

        [StringLength(21)]
        [Required]
        public string CustomerId { get; set; }
       

        [StringLength(5)]
        public string BankId { get; set; }

        [StringLength(11)]
        public string TxnCode { get; set; }
        
        public DateTime TxnDate { get; set; }

        public decimal TxnAmount { get; set; }
        
        [StringLength(200)]
        public string TxnText { get; set; }

        [StringLength(3)]
        public string CurrencyCode { get; set; }
        
        public decimal TxnCurAmount { get; set; }

        [StringLength(40)]
        public string CorrAccount { get; set; }

        [StringLength(200)]
        public string CorrName { get; set; }

        [StringLength(11)]
        public string CorrBank { get; set; }

        [StringLength(2)]
        public string CorrCountry { get; set; }

        [StringLength(74)]
        public string CustomerSegment { get; set; }

        [StringLength(20)]
        public string CustomerType { get; set; }

        [StringLength(1)]
        public string SalaryFlag { get; set; }

        [StringLength(16)]
        public string ProductId { get; set; }

    }
}
