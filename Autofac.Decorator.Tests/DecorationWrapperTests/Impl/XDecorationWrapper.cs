using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Decorator.Tests.DecorationWrapperTests.Impl
{
    class XDecorationWrapper : DecorationWrapper<IXService>, IXService
    {
        public XDecorationWrapper(IXService original, IEnumerable<IDecoratorProvider<IXService>> providers)
            : base(original, providers)
        { }

        public int X()
        {
            return this.Decorated.X();
        }
    }
}
