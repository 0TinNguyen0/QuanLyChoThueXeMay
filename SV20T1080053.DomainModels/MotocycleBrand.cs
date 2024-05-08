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

    public enum Brand_Name
    {
        Honda,
        Yamaha,
        Suzuki,
    }


    [Table("MotocycleBrands")]
    public class MotocycleBrand
    {
        [Key]
        public int BrandId { get; set; }

        public Brand_Name BrandName { get; set; }

        //Relationship
        public IEnumerable<Motorcycle> Motorcycles { get; set; }
    }
}
