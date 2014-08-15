using System.Collections.Generic;
using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav.Models
{
    public class FoundThemes
    {
        private readonly List<Theme> _found;
        private readonly string _searchText;

        public FoundThemes(List<Theme> found, string searchText)
        {
            _found = found;
            _searchText = searchText;
        }

        public List<Theme> Found
        {
            get { return _found; }
        }

        public string SearchText
        {
            get { return _searchText; }
        }
    }
}