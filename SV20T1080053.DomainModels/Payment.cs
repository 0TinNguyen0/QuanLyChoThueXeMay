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
    public enum PaymentStatus
    {
        COMPLETED,
        FAILED,
        CANCELED,
    }


    [Table("Payments")]
    public class Payment
    {
        [Key]
        public int Payment_ID { get; set; }

        [ForeignKey("Rental_ID")]
        public int Rental_ID { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Money { get; set; }

        public PaymentStatus Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Payment_Method { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Payment_Date { get; set;} = DateTime.Now;

        //Relationship
        public Rental Rental { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
