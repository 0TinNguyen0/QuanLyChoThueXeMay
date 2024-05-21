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

    [Table("OrderDetails")]
    public class OrderDetail 
    {
        [Key]
        public int OrderDetailId { get; set; }

        [ForeignKey("MotorcycleId")]
        public int MotorcycleId { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }


        //Relationship
        public Order Order { get; set; }
        public Motorcycle Motorcycle { get; set; }
    }
}
