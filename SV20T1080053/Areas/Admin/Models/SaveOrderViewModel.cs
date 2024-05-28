using SV20T1080053.DomainModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SV20T1080053.Areas.Admin.Models
{
    public class SaveOrderViewModel
    {
        public int OrderId { get; set; }

        [DisplayName("Người dùng")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public int UserId { get; set; }

        [DisplayName("Ngày bắt đầu")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Ngày kết thúc")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Phương thức thanh toán")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public int PaymentId { get; set; }

        public IEnumerable<User> Users { get; set; } = new List<User>();
        public IEnumerable<Motorcycle> Motorcycles { get; set; } = new List<Motorcycle>();
        public IEnumerable<Payment> Payments { get; set; } = new List<Payment>();
    }
}