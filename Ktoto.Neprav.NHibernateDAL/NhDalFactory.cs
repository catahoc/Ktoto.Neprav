using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Ktoto.Neprav.DAL;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;

namespace Ktoto.Neprav
{
    public class NhDalFactory: IDalFactory
    {
        private readonly ISessionFactory _sessionFactory;

        private NhDalFactory(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

		public static NhDalFactory Create(string connectionString, bool expose)
        {

	        var dbConfig = MsSqlConfiguration.MsSql2012
		        .Dialect<MsSql2012Dialect>()
		        .Driver<SqlClientDriver>()
		        .ConnectionString(connectionString);
            var cfg = Fluently.Configure()
                    .Mappings(_ => _.FluentMappings.AddFromAssemblyOf<AuthorMapping>())
                    .Database(dbConfig)
                    .ExposeConfiguration(_ =>
                        {
	                        if (expose)
	                        {
								var export = new SchemaExport(_);
								export.Execute(true, true, false);
							}
                        });
            var sessionFactory = cfg.BuildSessionFactory();
            return new NhDalFactory(sessionFactory);
        }

        public IDal Create()
        {
            return new NhDal(_sessionFactory);
        }
    }
}