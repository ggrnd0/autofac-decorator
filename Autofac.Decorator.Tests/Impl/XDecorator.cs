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
        private XFactor _factor;
        private int _mult;

        public XDecorator(
            IXService target,
            XFactor factor,
            int mult
            )
        {
            _target = target;
            _factor = factor;
            _mult = mult;
        }

        public int X()
        {
            return _target.X() + _factor.Factor * _mult;
        }
    }
}
