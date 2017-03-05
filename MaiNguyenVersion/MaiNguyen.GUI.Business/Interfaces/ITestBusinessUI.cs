using MaiNguyen.GUI.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Interfaces
{
    public interface ITestBusinessUI
    {
        List<TestViewModel> GetTest();
    }
}
