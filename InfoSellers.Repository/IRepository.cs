using System.Collections.Generic;

namespace InfoSellers.Repository
{
    public interface IRepository<T, K>
    {
        List<T> Read();
        T ReadById(K id);
        T Create(T entity);
        T Update(T entity);
        void Delete(K id);
    }
}