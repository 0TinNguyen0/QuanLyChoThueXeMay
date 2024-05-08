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
        InProgress,
        Completed,
        Cancelled
    }

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
        
        public Status Status {  get; set; }

        //Relationship
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public User User { get; set; }
        
    }
}
