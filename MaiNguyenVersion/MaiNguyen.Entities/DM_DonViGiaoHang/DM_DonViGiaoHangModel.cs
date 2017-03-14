using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Entities.DM_DonViGiaoHang
{
    [DataContract]
    public class DM_DonViGiaoHangModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Ten { get; set; }
        [DataMember]
        public int Deleted { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public string ModifiedDate { get; set; }
        [DataMember]
        public int Total { get; set; }
    }
}
