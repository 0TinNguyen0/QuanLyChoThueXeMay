using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
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
        NotRented,
        Rented,
    }

    [Table("MotocycleStatus")]
    public class MotocycleStatus
    {
        [Key]
        public int Satatus_ID { get; set; }

        [Required]
        [StringLength(50)]
        public Status Status_Name { get; set; } 

        //Relationship
        public IEnumerable<Invoice>  Invoices { get; set; }
    }
}
