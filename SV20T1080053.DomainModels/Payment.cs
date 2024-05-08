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
        public int PaymentId { get; set; }

        [ForeignKey("RentalId")]
        public int RentalId { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Money { get; set; }

        public PaymentStatus Status { get; set; }

        [ForeignKey("PaymentMethodId")]
        public int PaymentMethodId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PaymentDate { get; set;} = DateTime.Now;

        //Relationship
        public Rental Rental { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
