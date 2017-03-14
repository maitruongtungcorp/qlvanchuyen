using log4net;
using MaiNguyen.Data.Common;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.Common;
using MaiNguyen.Service.Interfaces.Common;
using System;
using System.Collections.Generic;

namespace MaiNguyen.Service.Implements.Common
{
    public class CommonService : ICommonService
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(CommonService));

        public CommonService() : base()
        {
        }

        public List<ThanhPhoModel> DanhSachThanhPho()
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    CommonDac qlDac = new CommonDac(unitOfWork);
                    var lstThanhPho = qlDac.DanhSachThanhPho();
                    return lstThanhPho;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return null;
                }
            }
        }
    }
}