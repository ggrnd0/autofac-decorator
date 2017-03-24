using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Decorator.Tests.Impl
{
    class XDecoratorProvider : IDecoratorProvider<IXService>
    {
        private int _add;

        public XDecoratorProvider(int add)
        {
            _add = add;
        }

        public IXService Decorate(IXService target)
        {
            return new XDecorator(target, _add);
        }
    }
}
