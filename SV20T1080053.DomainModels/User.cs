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
    public enum Roles 
    {
        Employee,
        Customer
    }

    [Table("Users")]
    public class User : ISoftDelete
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string? Photo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Address { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }

        public Roles Role { get; set; }
        //Relationship
        public IEnumerable<Motorcycle> Motorcycles { get; set; }
        public IEnumerable<Rental> Rentals { get; set; }

        public string GetRoleName()
        {
            switch (Role)
            {
                case Roles.Employee:
                    return "Nhân viên";
                case Roles.Customer:
                    return "Khách hàng";
                default:
                    return string.Empty;
            }
        }
    }
}
