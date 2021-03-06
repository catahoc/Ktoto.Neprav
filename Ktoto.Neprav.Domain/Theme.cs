﻿using System;
using System.Collections.Generic;

namespace Ktoto.Neprav
{
	public class Theme : LikeTarget
    {
        public Theme()
        {
            Comments = new List<Comment>();
        }

		public virtual ICollection<Comment> Comments { get; set; }
		public virtual DateTimeOffset Created { get; set; }
        public virtual Author Author { get; set; }
        public virtual string Name { get; set; }
    }
}
