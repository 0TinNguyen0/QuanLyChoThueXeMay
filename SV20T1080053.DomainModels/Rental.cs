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
    [Table("Rentals")]
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public int MotorcycleId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate {  get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set;} = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Status {  get; set; } = string.Empty;

        //Relationship
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public User User { get; set; }
        
    }
}
