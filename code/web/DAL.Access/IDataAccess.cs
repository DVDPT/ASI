using System.Linq;

namespace DAL.Access
{
    public interface IDataAccess
    {
    }

    public interface IDataAccess<T, in K> : IDataAccess where T : class
    {
        T Get(K key);

        IQueryable<T> Query();

        void Create(T obj);

        void Update(T obj);

        void Delete(T obj);

        void Delete(K key);
    }
}
