using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    ///

    public enum InvoiceStatus
    {
        NotRent,
        Rent,
    }

    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [ForeignKey("RentalId")]
        public int RentalId { get; set; }

        [Required]
        [MaxLength(50)]
        public decimal TotalAmount { get; set; } 
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PaymentDate {  get; set; } = DateTime.Now;

        public InvoiceStatus Status { get; set; }

        //Relationship
        public Rental Rental { get; set; }
    }
}
