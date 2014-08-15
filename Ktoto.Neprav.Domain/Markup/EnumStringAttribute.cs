using System;

namespace Ktoto.Neprav.Domain.Markup
{
    public class EnumStringAttribute: Attribute
    {
        private readonly string _value;

        public EnumStringAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}