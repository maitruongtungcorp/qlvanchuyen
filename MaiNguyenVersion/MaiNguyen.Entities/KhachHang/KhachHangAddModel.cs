using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace MaiNguyen.Entities.KhachHang
{
    [DataContract]
    public class KhachHangAddModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string MaKH { get; set; }
        [DataMember]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Không nhập quá 500 ký tự.")]
        [Required(ErrorMessage = "Bắt buộc nhập")]
        public string TenKH { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Bắt buộc nhập")]
        public string DienThoai { get; set; }
        [DataMember]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        [Required(ErrorMessage = "Bắt buộc nhập")]
        public string Email { get; set; }
        [DataMember]
        public string DiaChi { get; set; }
        [DataMember]
        public string TenCongTy { get; set; }
        [DataMember]
        public string Sales { get; set; }
        [DataMember]
        public string GhiChu { get; set; }
        [DataMember]
        public int? ThanhPhoID { get; set; }
        [DataMember]
        public int? SoDonHang { get; set; }
    }
}
