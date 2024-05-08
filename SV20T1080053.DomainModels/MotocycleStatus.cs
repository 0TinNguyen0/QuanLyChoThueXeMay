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
        public int StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public Status StatusName { get; set; } 

        //Relationship
        public IEnumerable<Invoice>  Invoices { get; set; }
    }
}
