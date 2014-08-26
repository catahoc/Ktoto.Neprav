using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace Ktoto.Neprav
{
	public class AuthCookieMapping: ClassMap<AuthCookie>
	{
		public AuthCookieMapping()
		{
			Id(_ => _.Id).GeneratedBy.Foreign("Author");
			HasOne(_ => _.Author).Constrained().ForeignKey();
			Map(_ => _.Hash);
		}
	}
}