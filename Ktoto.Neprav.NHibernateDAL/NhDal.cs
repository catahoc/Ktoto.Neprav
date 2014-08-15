using System.Linq;
using Ktoto.Neprav.DAL;
using NHibernate;
using NHibernate.Linq;

namespace Ktoto.Neprav
{
    public class NhDal: IDal
    {
        private readonly ISession _session;

        public NhDal(ISessionFactory factory)
        {
            _session = factory.OpenSession();
        }

        public IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }

        public void Attach<T>(T obj)
        {
            _session.Save(obj);
        }

        public void Delete<T>(T obj)
        {
            _session.Delete(obj);
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}