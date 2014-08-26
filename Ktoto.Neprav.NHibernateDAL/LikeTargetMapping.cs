using FluentNHibernate.Mapping;

namespace Ktoto.Neprav
{
	public class LikeTargetMapping : ClassMap<LikeTarget>
	{
		public LikeTargetMapping()
		{
			Id(_ => _.Id).GeneratedBy.Identity();
			HasManyToMany(_ => _.LikedAuthors);
		}
	}
}