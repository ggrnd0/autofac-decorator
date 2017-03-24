using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Decorator.Tests.Impl
{
    class XDecorator : IXService
    {
        private IXService _target;
        private int _add;

        public XDecorator(IXService target, int add)
        {
            _target = target;
            _add = add;
        }

        public int X()
        {
            return _target.X() + _add;
        }
    }
}
