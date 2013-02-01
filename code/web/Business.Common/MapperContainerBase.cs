using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.OrdersCenter;

namespace Business.Common
{
    public class MapperContainerBase<T> : IDisposable where T : DbContext, new()
    {
        private bool _disposed;

        protected T DbContext { get; private set; }

        public MapperContainerBase(Func<T> contextFactory = null)
        {
            DbContext = contextFactory == null ? new T() : contextFactory();
        }

        protected E VerifyDisposedAndReturnValue<E>(E e)
        {
            EnsureThatObjectIsNotDisposed();
            return e;
        }

        private void EnsureThatObjectIsNotDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
        }

        public virtual void Dispose()
        {
            DbContext.SaveChanges();
            DbContext.Dispose();
            DbContext = null;
            _disposed = false;
        }
    }
}
