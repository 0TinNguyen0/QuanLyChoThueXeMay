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
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        public int Invoice_ID { get; set; }

        [ForeignKey("Rental_ID")]
        public int Rental_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public decimal Total_Amount { get; set; } 
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Invoice_Date { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Payment_Date {  get; set; } = DateTime.Now;

        [Required]
        public int Status { get; set; }


        //Relationship
        public MotocycleStatus MotocycleStatus {  get; set; }
        public Rental Rental { get; set; }
    }
}
