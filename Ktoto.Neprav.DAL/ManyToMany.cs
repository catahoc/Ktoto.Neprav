using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Ktoto.Neprav.DAL
{
	public class ManyToMany<TLeft, TRight>
	{
		private readonly PropertyInfo _rightsOfLeft;
		private readonly PropertyInfo _leftsOfRight;

		public ManyToMany(Expression<Func<TLeft, ICollection<TRight>>> rightsOfLeft,
			Expression<Func<TRight, ICollection<TLeft>>> leftsOfRight)
		{
			try
			{
				_rightsOfLeft = (PropertyInfo)((MemberExpression)rightsOfLeft.Body).Member;

			}
			catch (Exception)
			{
				_rightsOfLeft = null;
			}
			try
			{
				_leftsOfRight = (PropertyInfo)((MemberExpression)leftsOfRight.Body).Member;

			}
			catch (Exception)
			{
				_leftsOfRight = null;
			}
		}

		public void Bind(TLeft left, TRight right)
		{
			if (_rightsOfLeft != null)
			{
				var container = (ICollection<TRight>)_rightsOfLeft.GetValue(left);
				container.Add(right);
			}
		}

		public void Unbind(TLeft left, TRight right)
		{
			if (_rightsOfLeft != null)
			{
				var container = (ICollection<TRight>) _rightsOfLeft.GetValue(left);
				container.Remove(right);
			}
		}
	}
}