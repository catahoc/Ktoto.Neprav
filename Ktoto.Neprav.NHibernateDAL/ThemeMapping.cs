using FluentNHibernate.Mapping;
using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav
{
    public class ThemeMapping: SubclassMap<Theme>
    {
        public ThemeMapping()
        {
			KeyColumn("ID");

            Map(_ => _.Name);

            References(_ => _.Author);

            HasMany(_ => _.Comments);
        }
    }
}