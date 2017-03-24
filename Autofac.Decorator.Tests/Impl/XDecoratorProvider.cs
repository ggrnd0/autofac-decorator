using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Decorator.Tests.Impl
{
    class XDecoratorProvider : IDecoratorProvider<IXService>
    {
        private XFactor _factor;
        private int _mult;

        public XDecoratorProvider(
            XFactor factor,
            int mult
            )
        {
            _factor = factor;
            _mult = mult;
        }

        public IXService Decorate(IXService target)
        {
            return new XDecorator(target, _factor, _mult);
        }
    }
}
