using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using NguyenDucThien__241230854.Validation;

namespace NguyenDucThien__241230854.Models
{
    [ModelMetadataType(typeof(HangHoaMetadata))]
    public partial class HangHoa
    {
    }

    public class HangHoaMetadata
    {
        [Required(ErrorMessage = "Vui lòng chọn loại hàng")]
        [Display(Name = "MaLoai")]
        public int MaLoai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên hàng")]
        [StringLength(50, ErrorMessage = "Tên hàng tối đa 50 ký tự")]
        [Display(Name = "TenHang")]
        public string TenHang { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Range(100, 5000, ErrorMessage = "Giá phải là số và nằm trong giới hạn từ 100 đến 5000")]
        [Display(Name = "Gia")]
        public decimal? Gia { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên file ảnh")]
        [StringLength(100)]
        [AnhFileExtension]
        [Display(Name = "Anh")]
        public string? Anh { get; set; }
    }
}