using System.Collections.Generic;
using System.Linq;
using System;
using Ktoto.Neprav.Markup;

namespace Ktoto.Neprav.Utils
{
    public static class EnumHelpers
    {
        public static string EnumToString(this object enumVal)
        {
            return enumVal.GetType()
                          .GetMember(enumVal.ToString())
                          .Single()
                          .GetCustomAttributes(true)
                          .OfType<EnumStringAttribute>()
                          .Single()
                          .Value;
        }

        public static IEnumerable<T> Enumerate<T>()
        {
            return Enum.GetValues(typeof (T)).Cast<T>();
        }
    }
}