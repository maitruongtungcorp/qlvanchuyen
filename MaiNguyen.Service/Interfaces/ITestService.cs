﻿using MaiNguyen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Service.Interfaces
{
    public interface ITestService
    {
        List<TestModel> GetTest();
    }
}
