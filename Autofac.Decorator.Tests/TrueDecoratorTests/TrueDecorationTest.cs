﻿using System;
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
                .WithParameter("add", 900);

            b.RegisterDecorator<IXService>(t => t, fromKey: "X", toKey: "Y");
            b.RegisterTrueDecorator<XDecorator>()
                .Named<IXService>("Y")
                .WithParameter("add", 8000);
            b.RegisterTrueDecorator<XDecorator>()
                .Named<IXService>("Y")
                .WithParameter("add", 80000);

            b.RegisterDecorator<IXService>(t => t, fromKey: "X");
            b.RegisterTrueDecorator<XDecorator>()
                .As<IXService>()
                .WithParameter("add", 700000);

            var c = b.Build();

            using (var scope = c.BeginLifetimeScope())
            {
                var x = scope.ResolveNamed<IXService>("X");

                Assert.AreEqual(x.X(), 991);

                x = scope.ResolveNamed<IXService>("Y");

                Assert.AreEqual(x.X(), 88991);

                x = scope.Resolve<IXService>();

                Assert.AreEqual(x.X(), 700991);
            }
        }
    }
}
