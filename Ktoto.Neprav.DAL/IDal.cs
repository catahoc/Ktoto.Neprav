using System;
using System.Linq;

namespace Ktoto.Neprav.DAL
{
    public interface IDal : IDisposable
    {
        IQueryable<T> Query<T>();
	    T Get<T>(object key);
        void Attach<T>(T obj);
        void Delete<T>(T obj);
    }
}
