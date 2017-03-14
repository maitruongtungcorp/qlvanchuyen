using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Entities.DM_LyDoThatBai
{
    [DataContract]
    public class DM_LyDoThatBaiAddModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string LyDo { get; set; }
        [DataMember]
        public int Deleted { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
    }
}
