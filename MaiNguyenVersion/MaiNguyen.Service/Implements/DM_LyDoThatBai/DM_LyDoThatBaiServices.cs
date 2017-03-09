using log4net;
using MaiNguyen.Data.DM_LyDoThatBai;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.DM_LyDoThatBai;
using MaiNguyen.Service.Interfaces.DM_LyDoThatBai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Service.Implements.DM_LyDoThatBai
{
    public class DM_LyDoThatBaiServices : IDM_LyDoThatBaiServices
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(DM_LyDoThatBaiServices));

        public DM_LyDoThatBaiServices() : base()
        {
        }
        public List<DM_LyDoThatBaiModel> DanhSachDM_LyDoThatBai(DM_LyDoThatBaiPagingCriteria objCriteria)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                var lstDM_LyDoThatBai = new List<DM_LyDoThatBaiModel>();
                try
                {
                    DM_LyDoThatBaiDac qlDac = new DM_LyDoThatBaiDac(unitOfWork);
                    lstDM_LyDoThatBai = qlDac.DanhSachDM_LyDoThatBai(objCriteria);
                    return lstDM_LyDoThatBai;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return lstDM_LyDoThatBai;
                }
            }
        }
    }
}
