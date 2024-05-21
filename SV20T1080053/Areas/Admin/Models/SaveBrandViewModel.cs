using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SV20T1080053.Areas.Admin.Models
{
    public class SaveBrandViewModel
    {
        public int BrandId { get; set; }

        [DisplayName("Tên hãng xe")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string BrandName { get; set;}

    }
}
