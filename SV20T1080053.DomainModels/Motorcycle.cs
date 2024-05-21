using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    /// 

    //public enum Brand
    //{
    //    Honda,
    //    Yamaha,
    //    Suzuki,
    //}

    public enum Type
    {
        Manual,
        Automatic,
    }

    public enum StatusName
    {
        NotRented,
        Rented,
    }
   
    [Table("Motorcycles")]
    public class Motorcycle 
    {
        [Key]
        public int MotorcycleId { get; set; }

        [ForeignKey("BrandId")]
        public int BrandId { get; set; }

        [Required]
        [StringLength(100)]
        public string MotorcycleName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Photo { get; set; } = string.Empty;
        public Type Type { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ReleaseYear { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Color { get; set; } = string.Empty;

        [Required]
        //[Precision(18, 2)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public StatusName Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; } = string.Empty;


        //Relationship

        public IEnumerable<OrderDetail> OrderDetail { get; set; }

        public Brand Brand { get; set; }

        public string GetTypeName()
        {
            switch (Type)
            {
                case Type.Manual:
                    return "Xe số";
                case Type.Automatic:
                    return "Xe tay ga";
                default:
                    return string.Empty;
            }
        }

        public string GetStatusName()
        {
            switch (Status)
            {
                case StatusName.NotRented:
                    return "Chưa thuê";
                case StatusName.Rented:
                    return "Đang thuê";
                default:
                    return string.Empty;
            }
        }
    }
}
