using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDataAccess
    {
    }

    public interface IDataAccess<T, K> : IDataAccess where T : class
    {
        T Get(K key);

        IQueryable<T> Query();

        void Create(T obj);

        void Update(T obj);

        void Delete(T obj);

        void Delete(K key);
    }
}
