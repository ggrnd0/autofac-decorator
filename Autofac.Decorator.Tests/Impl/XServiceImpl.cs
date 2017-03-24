using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Decorator.Tests.Impl
{
    class XServiceImpl : IXService
    {
        public int X()
        {
            return 1;
        }
    }
}
