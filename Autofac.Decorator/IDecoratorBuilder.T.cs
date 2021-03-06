﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Decorator
{
    public interface IDecoratorProvider<T>
    {
        T Decorate(T target);
    }
}
