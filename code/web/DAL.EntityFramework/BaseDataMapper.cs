using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Access;

namespace DAL.EntityFramework
{
    public abstract class BaseDataMapper<TValue, TDerivedValue, TKey> : IDataMapper<TValue, TKey>
        where TValue : class
        where TDerivedValue : class, TValue
    {
        private readonly IDbSet<TDerivedValue> _dbSet;

        protected BaseDataMapper(IDbSet<TDerivedValue> dbSet)
        {

            _dbSet = dbSet;
        }


        public abstract TValue Get(TKey key);

        public IQueryable<TValue> Query()
        {
            return _dbSet;
        }

        public void Create(TValue obj)
        {
            _dbSet.Add((TDerivedValue)obj);
        }

        public void Update(TValue obj)
        {

        }

        public void Delete(TValue obj)
        {
            _dbSet.Remove((TDerivedValue)obj);
        }

        public void Delete(TKey key)
        {
            Delete(Get(key));
        }
    }

}
