using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.ViewModel
{
    public class DM_LyDoThatBaiViewModel
    {
        public int Id { set; get; }
        public string LyDo { set; get; }
        public int Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int total { get; set; }
    }
}
