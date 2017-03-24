using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Autofac.Decorator.Tests.Impl;

namespace Autofac.Decorator.Tests.DecorationWrapperTests
{
    [TestClass]
    public class DecorationWrapperTest
    {
        [TestMethod]
        public void Test()
        {
            var b = new ContainerBuilder();
            
            b.RegisterType<XServiceImpl>().Named<IXService>("X");
            b.RegisterDecorator<IXService>(
                (s, t) => new XDecorationWrapper(t, s.Resolve<IComponentContext>().Resolve<IEnumerable<IDecoratorProvider<IXService>>>()),
                fromKey: "X"
                );

            b.RegisterType<XDecoratorProvider>()
                .As<IDecoratorProvider<IXService>>()
                .WithParameter("add", 90);
            b.RegisterType<XDecoratorProvider>()
                .As<IDecoratorProvider<IXService>>()
                .WithParameter("add", 900);

            var c = b.Build();

            using (var scope = c.BeginLifetimeScope())
            {
                var x = scope.Resolve<IXService>();

                Assert.AreEqual(x.X(), 991);
            }
        }
    }
}
