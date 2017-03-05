using log4net;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaiNguyen.Data
{
    /// <summary>
    /// TestDac data access component. Manages CRUD operations for the TestDac table.
    /// </summary>
    public partial class TestDac: DataAccessComponent
    {
        #region Dung chung
        protected static readonly ILog log = LogManager.GetLogger(typeof(TestDac));

        private Database _database;
        private IUnitOfWork _unitOfWork;

        public TestDac(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork.QuanLyVanChuyenDatabase;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public List<TestModel> GetTest()
        {
            try
            {
               // Database db = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                return _database.ExecuteSprocAccessor<TestModel>("GetDanhSach").ToList();
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
