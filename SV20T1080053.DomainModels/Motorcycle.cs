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
    [Table("Motorcycles")]
    public class Motorcycle
    {
        [Key]
        public int MotorcycleId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("BrandId")]
        public int BrandId { get; set; }

        [ForeignKey("TypeId")]
        public int TypeId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Year { get; set; } = DateTime.Now;

        [Required]
        [StringLength(100)]
        public string Photo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Color { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Description {  get; set; } = string.Empty;

        [Required]
        //[Precision(18, 2)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rental_Price {  get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = string.Empty;

        //Relationship
        public User User { get; set; }
        public MotocycleType Type { get; set; }

        public MotocycleBrand Brand { get; set; }
    }
}
