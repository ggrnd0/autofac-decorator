using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Decorator
{
    public abstract class DecorationWrapper<T>
        where T : class
    {
        private T _decorated;
        private readonly T _original;
        private readonly IEnumerable<IDecoratorProvider<T>> _providers;

        protected T Decorated
        {
            get { return _decorated ?? (_decorated = Decorate(_original, _providers)); }
        }

        protected DecorationWrapper(T original, IEnumerable<IDecoratorProvider<T>> providers)
        {
            _original = original;
            _providers = providers;
        }

        private T Decorate(T original, IEnumerable<IDecoratorProvider<T>> providers)
        {
            T decorated = original;
            foreach (var provider in providers)
            {
                decorated = provider.Decorate(decorated);
            }
            return decorated;
        }
    }
}
