using FluentNHibernate.Mapping;

namespace Ktoto.Neprav
{
	public class FeedMapping : ClassMap<Feed>
	{
		public FeedMapping()
		{
			Id(_ => _.Id).GeneratedBy.Identity();

			HasMany(_ => _.Comments);
			HasMany(_ => _.Opinions);

			References(_ => _.Author);
		}
	}
}