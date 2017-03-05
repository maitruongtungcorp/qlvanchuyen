using AutoMapper;
using MaiNguyen.Entities;
using MaiNguyen.GUI.Business.Interfaces;
using MaiNguyen.GUI.Business.ViewModel;
using MaiNguyen.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Implements
{
    public class TestBusinessUI:BaseBusiness, ITestBusinessUI
    {
        public TestBusinessUI() : base() { }
        public List<TestViewModel> GetTest()
        {
            var temp = dbContext.GetTest();
            var list = Mapper.Map<List<TestModel>,List<TestViewModel>>(temp);
            return list;
        }
    }
}
