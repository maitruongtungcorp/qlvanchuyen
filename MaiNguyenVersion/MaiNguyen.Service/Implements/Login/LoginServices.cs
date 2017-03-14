using log4net;
using MaiNguyen.Data.Login;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.Login;
using MaiNguyen.Service.Interfaces.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Service.Implements.Login
{
    public class LoginServices : ILoginServices
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(LoginServices));

        public LoginServices() : base()
        {
        }
        public LoginModel Login(string userName, string passWord)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                var login = new LoginModel();
                try
                {
                    LoginDac qlDac = new LoginDac(unitOfWork);
                    login = qlDac.Login(userName, passWord);
                    return login;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return login;
                }
            }
        }
    }
}
