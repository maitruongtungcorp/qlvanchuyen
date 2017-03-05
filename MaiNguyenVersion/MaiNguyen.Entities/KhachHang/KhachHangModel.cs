using System.Runtime.Serialization;

namespace MaiNguyen.Entities.KhachHang
{
    [DataContract]
    public class KhachHangModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string MaKH { get; set; }

        [DataMember]
        public string TenKH { get; set; }

        [DataMember]
        public string DienThoai { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string DiaChi { get; set; }

        [DataMember]
        public string TenCongTy { get; set; }

        [DataMember]
        public int Sales { get; set; }

        [DataMember]
        public int Total { get; set; }
    }
}