﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Entities.KhachHang
{
    [DataContract]
    public class KhachHangModel
    {
        [DataMember]
        public string Name { set; get; }
        [DataMember]
        public string Alias { set; get; }
    }
}
