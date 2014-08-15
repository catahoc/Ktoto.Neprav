using FluentNHibernate.Mapping;

namespace Ktoto.Neprav
{
    public static class FluentExtensions
    {
        public static IdentityPart AutoIncrement(this IdentityPart id)
        {
            return id.GeneratedBy.Sequence("global_seq");
        }
    }
}