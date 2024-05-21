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
        Pending,
        Completed,
        Failed,
        Canceled,
    }
    public enum PaymentName
    {
        CashPayment,
        BankTransfer,
    }

    [Table("Payments")]
    public class Payment 
    {
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public PaymentName PaymentName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PaymentDate { get; set;} = DateTime.Now;
        public PaymentStatus PaymentStatus { get; set; }
        

        //Relationship
        public IEnumerable<Order> Orders { get; set; }
        public User User { get; set; }

        public string GetPaymentStatus()
        {
            switch (PaymentStatus)
            {
                case PaymentStatus.Pending:
                    return "Đang xử lý";
                case PaymentStatus.Completed:
                    return "Hoàn thành";
                case PaymentStatus.Failed:
                    return "Thất bại";
                case PaymentStatus.Canceled:
                    return "Đã hủy";
                default:
                    return string.Empty;
            }
        }
    }
}
