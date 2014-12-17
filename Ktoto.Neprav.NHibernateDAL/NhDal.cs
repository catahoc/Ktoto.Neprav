using System.Linq;
using System.Transactions;
using Ktoto.Neprav.DAL;
using NHibernate;
using NHibernate.Linq;

namespace Ktoto.Neprav
{
    public class NhDal: IDal
    {
        private readonly ISession _session;
	    private readonly TransactionScope _scope;

        public NhDal(ISessionFactory factory)
        {
			_scope = new TransactionScope();
			_session = factory.OpenSession();

        }

        public IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }

	    public T Get<T>(object key)
	    {
		    return _session.Get<T>(key);
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
			_session.Flush();
			_session.Dispose();
			_scope.Complete();
			_scope.Dispose();
        }
    }
}