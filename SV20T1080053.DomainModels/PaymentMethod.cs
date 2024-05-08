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
    public enum Method_Name
    {
        CashPayment,
        BankTransfer,
        Credit,
    }

    [Table("PaymentMethods")]
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }

        [Required]
        [MaxLength(50)]
        public string MethodName { get; set; } = string.Empty;

        //Relationship
        public IEnumerable<Payment> Payments { get; set; }
    }
}
