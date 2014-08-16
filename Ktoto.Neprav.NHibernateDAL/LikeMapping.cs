using FluentNHibernate.Mapping;
using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav
{
	public class LikeMapping: ClassMap<Like>
	{
		public LikeMapping()
		{
			Id(_ => _.Id).GeneratedBy.Identity();

			References(_ => _.Author);
			References(_ => _.Target);
		}
	}
}