using Ktoto.Neprav.Markup;

namespace Ktoto.Neprav
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