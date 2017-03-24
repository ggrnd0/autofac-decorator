using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Autofac.Decorator.Tests.Impl;

namespace Autofac.Decorator.Tests.TrueDecoratorTests
{
    [TestClass]
    public class TrueDecoratorTest
    {
        [TestMethod]
        public void Test()
        {
            var b = new ContainerBuilder();

            b.RegisterInstance(new XFactor(3));

            b.RegisterType<XServiceImpl>().Named<IXService>("X");
            b.RegisterTrueDecorator<XDecorator>()
                .Named<IXService>("X")
                .WithParameter("mult", 10);
            b.RegisterTrueDecorator<XDecorator>()
                .Named<IXService>("X")
                .WithParameter("mult", 100);

            b.RegisterDecorator<IXService>(t => t, fromKey: "X", toKey: "Y");
            b.RegisterTrueDecorator<XDecorator>()
                .Named<IXService>("Y")
                .WithParameter("mult", 1000);
            b.RegisterTrueDecorator<XDecorator>()
                .Named<IXService>("Y")
                .WithParameter("mult", 10000);

            b.RegisterDecorator<IXService>(t => t, fromKey: "X");
            b.RegisterTrueDecorator<XDecorator>()
                .As<IXService>()
                .WithParameter("mult", 100000);

            var c = b.Build();

            using (var scope = c.BeginLifetimeScope())
            {
                var x = scope.ResolveNamed<IXService>("X");

                Assert.AreEqual(x.X(), 334);

                x = scope.ResolveNamed<IXService>("Y");

                Assert.AreEqual(x.X(), 33334);

                x = scope.Resolve<IXService>();

                Assert.AreEqual(x.X(), 300334);
            }
        }
    }
}
