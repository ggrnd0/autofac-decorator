using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Decorator.Tests.TrueDecoratorTests
{
    static class AutofacContainerBuilderExtensions
    {
        public static IRegistrationBuilder<TImplementer, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterTrueDecorator<TImplementer>(this ContainerBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
