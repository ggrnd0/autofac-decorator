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

            b.RegisterInstance(new XFactor(3));

            b.RegisterType<XServiceImpl>().Named<IXService>("X");
            b.RegisterDecorator<IXService>(
                (s, t) => new XDecorationWrapper(t, s.Resolve<IComponentContext>().Resolve<IEnumerable<IDecoratorProvider<IXService>>>()),
                fromKey: "X"
                );

            b.RegisterType<XDecoratorProvider>()
                .As<IDecoratorProvider<IXService>>()
                .WithParameter("mult", 10);
            b.RegisterType<XDecoratorProvider>()
                .As<IDecoratorProvider<IXService>>()
                .WithParameter("mult", 100);

            var c = b.Build();

            using (var scope = c.BeginLifetimeScope())
            {
                var x = scope.Resolve<IXService>();

                Assert.AreEqual(x.X(), 334);
            }
        }
    }
}
