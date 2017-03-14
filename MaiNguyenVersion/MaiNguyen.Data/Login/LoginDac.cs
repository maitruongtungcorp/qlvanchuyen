using log4net;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.Login;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Data.Login
{
    public class LoginDac : DataAccessComponent
    {
        #region Dung chung

        protected static readonly ILog log = LogManager.GetLogger(typeof(LoginDac));

        private Database _database;
        private IUnitOfWork _unitOfWork;

        public LoginDac(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork.QuanLyVanChuyenDatabase;
            _unitOfWork = unitOfWork;
        }

        #endregion Dung chung

        #region Method

        public LoginModel Login(string userName, string passWord)
        {
            try
            {
                return _database.ExecuteSprocAccessor<LoginModel>("Login", userName, passWord).SingleOrDefault();
            }
            catch (Exception ex)
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion Method
    }
}
