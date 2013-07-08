using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Token
{
	public class Subtraction :
		BinaryOperator
	{
		public override int Precedence { get { return 4; } }
		public override string Symbol { get { return "-"; } }
		public override Expression.BinaryOperator Create(Expression.Abstract left, Expression.Abstract right)
		{
			return new Expression.Subtraction(left, right);
		}
	}
}
