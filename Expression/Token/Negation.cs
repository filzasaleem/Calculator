using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Token
{
	public class Negation :
		UnaryOperator
	{
		public override int Precedence { get { return 9; } }
		public override string Symbol { get { return "-"; } }
		public override Expression.UnaryOperator Create(Expression.Abstract right)
		{
			return new Expression.Negation(right);
		}
	}
}
