using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.DomainModels
{
    [Table("Brands")]
    public class Brand
    {

        [Key]
        public int BrandId { get; set; }

        [Required]
        [StringLength(50)]
        public string BrandName { get; set; } = string.Empty;

        //Relationship

        public IEnumerable<Motorcycle> Motorcycles { get; set; }
    }
}
