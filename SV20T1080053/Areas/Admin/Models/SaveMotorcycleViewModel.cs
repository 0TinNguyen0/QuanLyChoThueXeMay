﻿using SV20T1080053.DomainModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SV20T1080053.Areas.Admin.Models
{
    public class SaveMotorcycleViewModel
    {
        public int MotorcycleId { get; set; }

        [DisplayName("Ảnh xe")]
        //[Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? Photo { get; set; }

        [DisplayName("Tên xe")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? MotocycleName { get; set; }

        [DisplayName("Hãng xe")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public int BrandId {  get; set; }

        [DisplayName("Hãng xe")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public IEnumerable<Brand> Brands { get; set; } = new List<Brand>();

        [DisplayName("Ngày sản xuất")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? ReleaseYear { get; set; }

        [DisplayName("Loại xe")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public SV20T1080053.DomainModels.Type? Type { get; set; }

        [DisplayName("Màu")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? Color { get; set; }

        [DisplayName("Giá thuê")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? Amount { get; set; } 

        [DisplayName("Trạng thái")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public SV20T1080053.DomainModels.StatusName? StatusName { get; set; }

        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string? Description { get; set; }
    }
}
