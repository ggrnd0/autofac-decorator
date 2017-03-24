using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Decorator.Tests.DecorationWrapperTests
{
    class XFactor
    {
        private readonly int _factor;

        public int Factor { get { return _factor; } }

        public XFactor(int factor)
        {
            _factor = factor;
        }
    }
}
