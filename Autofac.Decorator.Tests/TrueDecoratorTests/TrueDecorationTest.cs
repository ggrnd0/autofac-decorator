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
            
            b.RegisterType<XServiceImpl>().Named<IXService>("X");
            b.RegisterTrueDecorator<XDecorator>()
                .Named<IXService>("X")
                .WithParameter("add", 90);
            b.RegisterTrueDecorator<XDecorator>()
                .Named<IXService>("X")
                .WithParameter("add", 800);

            b.RegisterDecorator<IXService>(t => t, fromKey: "X", toKey: "Y");
            b.RegisterTrueDecorator<XDecorator>()
                .Named<IXService>("Y")
                .WithParameter("add", 7000);
            b.RegisterTrueDecorator<XDecorator>()
                .Named<IXService>("Y")
                .WithParameter("add", 60000);

            b.RegisterDecorator<IXService>(t => t, fromKey: "X");
            b.RegisterTrueDecorator<XDecorator>()
                .As<IXService>()
                .WithParameter("add", 500000);
            b.RegisterTrueDecorator<XDecorator>()
                .As<IXService>()
                .WithParameter("add", 4000000);

            var c = b.Build();

            using (var scope = c.BeginLifetimeScope())
            {
                var x = scope.ResolveNamed<IXService>("X");

                Assert.AreEqual(x.X(), 891);

                x = scope.ResolveNamed<IXService>("Y");

                Assert.AreEqual(x.X(), 67891);

                x = scope.Resolve<IXService>();

                Assert.AreEqual(x.X(), 4500891);
            }
        }
    }
}
