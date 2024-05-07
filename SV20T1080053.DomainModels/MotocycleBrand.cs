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
    [Table("MotocycleBrands")]
    public class MotocycleBrand
    {
        [Key]
        public int Brand_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        //Relationship
        public IEnumerable<Motorcycle> Motorcycles { get; set; }
    }
}
