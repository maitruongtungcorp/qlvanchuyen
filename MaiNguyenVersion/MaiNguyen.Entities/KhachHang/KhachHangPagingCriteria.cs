using System.Runtime.Serialization;

namespace MaiNguyen.Entities.KhachHang
{
    [DataContract]
    public class KhachHangPagingCriteria
    {
        [DataMember]
        public string Search { get; set; }

        [DataMember]
        public int? PageNum { get; set; }

        [DataMember]
        public int? PageSize { get; set; }
    }
}