using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Decorator.Tests.Impl
{
    class XServiceImpl : IXService
    {
        private XFactor _factor;

        public XServiceImpl(XFactor factor)
        {
            _factor = factor;
        }

        public int X()
        {
            return _factor.Factor + 1;
        }
    }
}
