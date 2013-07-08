using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Token
{
	public abstract class BinaryOperator :
		Abstract
	{
		public abstract string Symbol { get; }
		public abstract Expression.BinaryOperator Create(Expression.Abstract left, Expression.Abstract right);
	}
}
