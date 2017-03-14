using MaiNguyen.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Interfaces.Login
{
    public interface ILoginBusinessUI
    {
        LoginModel Login(string userName, string passWord);
    }
}
