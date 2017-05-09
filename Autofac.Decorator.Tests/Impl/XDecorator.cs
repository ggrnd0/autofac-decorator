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

    class XDecoratorAdd90 : XDecorator
    {
        public XDecoratorAdd90(IXService target)
            : base(target, 90)
        { }
    }

    class XDecoratorAdd800 : XDecorator
    {
        public XDecoratorAdd800(IXService target)
            : base(target, 800)
        { }
    }
}
