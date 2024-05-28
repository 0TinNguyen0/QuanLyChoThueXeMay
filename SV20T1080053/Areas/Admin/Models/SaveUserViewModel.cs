using SV20T1080053.DomainModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SV20T1080053.Areas.Admin.Models
{
    public class SaveUserViewModel
    {

        public int UserId { get; set; }

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? FullName { get; set; }

        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? BirthDate { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? Address { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? Password { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? Phone { get; set; }

        [DisplayName("Ảnh")]
        //[Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? Photo { get; set; }
    }
}
