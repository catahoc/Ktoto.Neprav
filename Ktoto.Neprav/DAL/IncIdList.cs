using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav.DAL
{
    public class IncIdList<T>: Collection<T> where T: HaveId
    {
        protected override void InsertItem(int index, T item)
        {
            var maxId = this.Any() ? this.Max(_ => _.Id) : 0;
            item.Id = maxId + 1;
            base.InsertItem(index, item);
        }
    }
}