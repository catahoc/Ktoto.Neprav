using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace Ktoto.Neprav
{
	public class OpinionMapping: ClassMap<Opinion>
	{
		public OpinionMapping()
		{
			CompositeId().KeyReference(_ => _.Author).KeyReference(_ => _.Feed);

			Map(_ => _.Color);

            References(_ => _.Author);
            References(_ => _.Feed);
        }
	}
}