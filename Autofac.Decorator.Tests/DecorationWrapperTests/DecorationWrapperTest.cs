using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac.Decorator.Tests.DecorationWrapperTests.Impl;
using System.Collections.Generic;

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
                .WithParameter("mult", 10)
                .InstancePerDependency();
            b.RegisterType<XDecoratorProvider>()
                .As<IDecoratorProvider<IXService>>()
                .WithParameter("mult", 100)
                .InstancePerDependency();

            var c = b.Build();

            var x = c.Resolve<IXService>();

            Assert.AreEqual(x.X(), 334);
        }
    }
}
