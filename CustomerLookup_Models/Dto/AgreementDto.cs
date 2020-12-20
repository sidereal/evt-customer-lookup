using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerLookup.Models.Dto
{
    public class AgreementDto
    {
        [StringLength(21)]
        [Required]
        public string Id { get; set; }

        [StringLength(21)]
        [Required]
        public string CustomerId { get; set; }

        [StringLength(5)]
        public string BankId { get; set; }

        [StringLength(16)]
        public string ProductId { get; set; }

        public decimal Balance { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }

        public decimal Amount { get; set; }

        public DateTime LastPaymentDate { get; set; }
        public DateTime NextPaymentDate { get; set; }

        [StringLength(10)]
        public string PaymentType { get; set; }

        public decimal Limit { get; set; }

        [StringLength(4)]
        public string AbwObjTypSchl { get; set; }

        [StringLength(32)]
        public string AbwObjId { get; set; }

        [StringLength(4)]
        public string AbwObjWhgSchl { get; set; }

        [StringLength(4)]
        public string Status { get; set; }

    }
}
