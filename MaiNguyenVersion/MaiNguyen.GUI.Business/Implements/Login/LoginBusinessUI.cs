using MaiNguyen.Entities.Login;
using MaiNguyen.GUI.Business.Interfaces.Login;
using MaiNguyen.Service.Implements.Login;
using MaiNguyen.Service.Interfaces.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Implements.Login
{
    public class LoginBusinessUI : ILoginBusinessUI
    {
        protected ILoginServices LoginService;
        public LoginBusinessUI() : base() { }
        public LoginModel Login(string userName, string passWord)
        {
            LoginService = new LoginServices();
            var login = LoginService.Login(userName, passWord);
            return login;
        }
    }
}
