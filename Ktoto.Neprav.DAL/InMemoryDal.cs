using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ktoto.Neprav.DAL
{
    public class InMemoryDal: IDal
    {
        private static readonly Dictionary<Type, object> Collections = new Dictionary<Type, object>(); 

        public void Dispose()
        {
            
        }

        public IQueryable<T> Query<T>()
        {
            return GetCollectionOfT<T>().AsQueryable();
        }

        public T Get<T>(object key)
        {
            var id = typeof (T).GetProperty("Id");
            var entityParameter = Expression.Parameter(typeof (T), "entity");
            var expr = Expression.Lambda<Func<T, bool>>(Expression.Equal(entityParameter, Expression.Constant(key)), entityParameter);
            var predicate = expr.Compile();
            return GetCollectionOfT<T>().SingleOrDefault(predicate);
        }

        public void Attach<T>(T obj)
        {
            GetCollectionOfT<T>().Add(obj);
        }

        public void Delete<T>(T obj)
        {
            var id = typeof(T).GetProperty("Id");
            var entityParameter = Expression.Parameter(typeof(T), "entity");
            var expr = Expression.Lambda<Predicate<T>>(Expression.Equal(entityParameter, Expression.Constant(id.GetValue(obj))), entityParameter);
            var predicate = expr.Compile();
            GetCollectionOfT<T>().RemoveAll(predicate);
        }

        private static List<T> GetCollectionOfT<T>()
        {
            lock (Collections)
            {
                object untypedResult;
                if (Collections.TryGetValue(typeof(T), out untypedResult))
                {
                    return (List<T>) untypedResult;
                }
                else
                {
                    var result = new List<T>();
                    Collections[typeof (T)] = result;
                    return result;
                }
            }
        }
    }
}