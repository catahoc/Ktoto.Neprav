using Ktoto.Neprav.Domain.Markup;

namespace Ktoto.Neprav.Domain
{
    public enum Opinion
    {
        [EnumString("За")]
        Good,

        [EnumString("Не определено")]
        Neutral,

        [EnumString("Против")]
        Bad
    }
}