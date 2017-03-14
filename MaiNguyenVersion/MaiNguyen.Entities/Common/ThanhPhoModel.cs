using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Entities.Common
{
    [DataContract]
    public class ThanhPhoModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Ten { get; set; }
    }
}
