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
    /// thông tin của tài khoản trong SQL 
    /// </summary>
    /// 
    [Table("Users")]
    public class User
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Full_Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        public string Birth_Date { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Photo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Phone { get; set; } = string.Empty;

        //Relationship
        public IEnumerable<Motorcycle> Motorcycles { get; set; }
        public IEnumerable<Rental> Rentals { get; set;}
    }
}
