using SiBRute.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiBRute.Service
{
    public class TestDI : ITestDI
    {
        public string GetData()
        {
            return "This is string from TestDI object";
        }
    }
}
