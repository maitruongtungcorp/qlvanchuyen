using log4net;
using MaiNguyen.Data;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities;
using MaiNguyen.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Service.Implements
{
    public class TestService: ITestService
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(TestService));
        public TestService() : base() { }
        public List<TestModel> GetTest()
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                var lstTest = new List<TestModel>();
                try
                {
                    TestDac qlDac = new TestDac(unitOfWork);
                    lstTest = qlDac.GetTest();
                    return lstTest;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return lstTest;
                }
            }

        }
    }
}
