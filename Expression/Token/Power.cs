using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Token
{
	public class Power :
		BinaryOperator
	{
		public override int Precedence { get { return 3; } }
		public override string Symbol { get { return "^"; } }
		public override Expression.BinaryOperator Create(Expression.Abstract left, Expression.Abstract right)
		{
			return new Expression.Power(left, right);
		}
	}
}
