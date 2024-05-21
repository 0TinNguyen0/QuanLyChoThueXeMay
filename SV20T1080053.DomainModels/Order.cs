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

    public enum Status
    {
        Pending,
        Completed,
        Canceled,
    }

    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("PaymentId")]
        public int PaymentId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate {  get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set;} = DateTime.Now;
        public Status Status { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        

        //Relationship
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public Payment Payment { get; set; }
        public User User { get; set; }

        public string GetStatus()
        {
            switch (Status)
            {
                case Status.Pending:
                    return "Đang xử lý";
                case Status.Completed:
                    return "Hoàn thành";
                case Status.Canceled:
                    return "Đã hủy";
                default:
                    return string.Empty;
            }
        }

    }
}
