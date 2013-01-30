using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Access;

namespace DAL.EntityFramework
{
    public abstract class BaseDataMapper<TValue, TKey> : IDataMapper<TValue, TKey> where TValue : class
    {
        private readonly IDbSet<TValue> _dbSet;

        protected BaseDataMapper(IDbSet<TValue> dbSet)
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
            _dbSet.Add(obj);
        }

        public void Update(TValue obj)
        {

        }

        public void Delete(TValue obj)
        {
            _dbSet.Remove(obj);
        }

        public void Delete(TKey key)
        {
            Delete(Get(key));
        }
    }

}
