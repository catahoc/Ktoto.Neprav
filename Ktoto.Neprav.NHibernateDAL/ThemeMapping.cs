using FluentNHibernate.Mapping;

namespace Ktoto.Neprav
{
    public class ThemeMapping: SubclassMap<Theme>
    {
        public ThemeMapping()
        {
			KeyColumn("ID");

            Map(_ => _.Name);
	        Map(_ => _.Created);

            References(_ => _.Author);

            HasMany(_ => _.Comments);
        }
    }
}