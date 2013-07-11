using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Token
{
	public abstract class UnaryOperator :
		Abstract
	{
		public abstract string Symbol { get; }
		public abstract Expression.UnaryOperator Create(Expression.Abstract right);
	}
}
