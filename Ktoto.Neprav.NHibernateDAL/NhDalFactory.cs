using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Ktoto.Neprav.DAL;
using NHibernate;
using NHibernate.Cfg;
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

        public static IDalFactory Create()
        {
            var dbConfig = OracleDataClientConfiguration.Oracle10
                  .Dialect("NHibernate.Dialect.Oracle10gDialect");

            dbConfig = dbConfig
                .Driver<OracleDataClientDriver>()
                .ConnectionString("data source=evol10; user id=amakhov; password=test");
            var cfg = Fluently.Configure()
                    .Mappings(_ => _.FluentMappings.AddFromAssemblyOf<AuthorMapping>())
                    .Database(dbConfig)
                    .ExposeConfiguration(_ =>
                        {
                            var export = new SchemaExport(_);
                            export.Execute(true, true, false);
                        });
            var sessionFactory = cfg.BuildSessionFactory();
            return new NhDalFactory(sessionFactory);
        }

        IDal IDalFactory.Create()
        {
            return new NhDal(_sessionFactory);
        }
    }
}