using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.DomainModels
{
    [Table("Vouchers")]
    public class Voucher
    {
        [Key]
        public int VoucherId { get; set; }

        public string name { get; set; }
    }
}
