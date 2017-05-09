using Autofac.Decorator.Tests.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Decorator.Tests.SimpleInjectTests
{
    [TestClass]
    public class SimpleInjectDecorationTest
    {
        [TestMethod]
        public void Test()
        {
            var b = new Container();

            b.Register<IXService, XServiceImpl>();
            b.RegisterDecorator<IXService, XDecoratorAdd90>();
            b.RegisterDecorator<IXService, XDecoratorAdd800>();

            var x = b.GetInstance<IXService>();

            Assert.AreEqual(x.X(), 891);
        }
    }
}
