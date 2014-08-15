using FluentNHibernate.Mapping;
using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav
{
    public class ThemeMapping: ClassMap<Theme>
    {
        public ThemeMapping()
        {
            Id(_ => _.Id).AutoIncrement();

            Map(_ => _.Name);

            References(_ => _.Author);

            HasMany(_ => _.Comments);
        }
    }
}