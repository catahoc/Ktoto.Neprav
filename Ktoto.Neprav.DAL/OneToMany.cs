using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Ktoto.Neprav.DAL
{
    public class OneToMany<TParent, TChild>
    {
        private readonly PropertyInfo _childrenOfParent;
        private readonly PropertyInfo _parentOfChild;

        public OneToMany(Expression<Func<TParent, ICollection<TChild>>> childrenOfParent,
                                   Expression<Func<TChild, TParent>> parentOfChild)
        {
            try
            {
                _childrenOfParent = (PropertyInfo)((MemberExpression)childrenOfParent.Body).Member;

            }
            catch (Exception)
            {
                _childrenOfParent = null;
            }
            try
            {
                _parentOfChild = (PropertyInfo)((MemberExpression)parentOfChild.Body).Member;

            }
            catch (Exception)
            {
                _parentOfChild = null;
            }
        }

        public void ParentReceivesChild(TParent parent, TChild child)
        {
            if (_childrenOfParent != null)
            {
                var container = (ICollection<TChild>)_childrenOfParent.GetValue(parent);
                container.Add(child);
            }
            if (_parentOfChild != null)
            {
                _parentOfChild.SetValue(child, parent);
            }
        }

        public void ParentLosesChild(TParent parent, TChild child)
        {
            if (_childrenOfParent != null)
            {
                var container = (ICollection<TChild>) _childrenOfParent.GetValue(parent);
                container.Remove(child);
            }
            if (_parentOfChild != null)
            {
                _parentOfChild.SetValue(child, null);
            }
        }
    }
}
