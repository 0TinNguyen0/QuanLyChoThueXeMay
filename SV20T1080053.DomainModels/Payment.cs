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
    public enum MethodName
    {
        CashPayment,
        BankTransfer,
        Credit,
    }

    [Table("Payments")]
    public class Payment : ISoftDelete
    {
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey("RentalId")]
        public int RentalId { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Money { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PaymentDate { get; set;} = DateTime.Now;
        public PaymentStatus PaymentStatus { get; set; }
        public MethodName MethodName { get; set; }

        //Relationship
        public Rental Rental { get; set; }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
