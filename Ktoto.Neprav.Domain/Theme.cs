using System;
using System.Collections.Generic;

namespace Ktoto.Neprav
{
	public class Theme : Feed
    {
		public virtual DateTimeOffset Created { get; set; }
        public virtual string Name { get; set; }
    }
}
