using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Entities.DM_NhaCungCap
{
    [DataContract]
    public class DM_NhaCungCapPagingCriteria
    {
        [DataMember]
        public string Search { get; set; }
        [DataMember]
        public int? PageNum { get; set; }
        [DataMember]
        public int? PageSize { get; set; }
    }
}
