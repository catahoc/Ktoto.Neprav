using System.Collections.Generic;

namespace Ktoto.Neprav.Models
{
    public class ThemeViewModel
    {
        private readonly ThemeOpinionViewModel[] _themeOpinionViewModels;
        private readonly Theme _theme;

        public ThemeViewModel(ThemeOpinionViewModel[] themeOpinionViewModels, Theme theme)
        {
            _themeOpinionViewModels = themeOpinionViewModels;
            _theme = theme;
        }

        public ThemeOpinionViewModel[] ThemeOpinionViewModels
        {
            get { return _themeOpinionViewModels; }
        }

        public Theme Theme
        {
            get { return _theme; }
        }
    }
}