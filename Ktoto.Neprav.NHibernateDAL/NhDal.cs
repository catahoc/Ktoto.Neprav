using System.Linq;
using System.Transactions;
using Ktoto.Neprav.DAL;
using NHibernate;
using NHibernate.Linq;

namespace Ktoto.Neprav
{
	public class NhDal : IDal
	{
		private readonly ISession _session;
		private readonly ITransaction _tx;

		public NhDal(ISessionFactory factory)
		{
			_session = factory.OpenSession();
			_tx = _session.BeginTransaction();

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
			_session.Flush();
		}

		public void Dispose()
		{
			_tx.Commit();
			_session.Dispose();
		}
	}
}