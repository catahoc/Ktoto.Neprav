using FluentNHibernate.Mapping;
using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav
{
	public class LikeTargetMapping : ClassMap<LikeTarget>
	{
		public LikeTargetMapping()
		{
			Id(_ => _.Id).GeneratedBy.Identity();
		}
	}
}