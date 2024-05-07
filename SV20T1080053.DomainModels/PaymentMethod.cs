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
    [Table("PaymentMethods")]
    public class PaymentMethod
    {
        [Key]
        public int Methods_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        //Relationship
        public IEnumerable<Payment> Payments { get; set; }
    }
}
