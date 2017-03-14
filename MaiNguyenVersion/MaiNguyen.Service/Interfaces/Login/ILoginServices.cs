using MaiNguyen.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Service.Interfaces.Login
{
    public interface ILoginServices
    {
        LoginModel Login(string userName, string passWord);
    }
}
