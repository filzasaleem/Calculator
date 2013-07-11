using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Token
{
	class RightParanthesis :
     BinaryOperator
	{
		public override int Precedence { get { return int.MaxValue; } }
		public override string Symbol { get { return ")"; } }
		public override Expression.BinaryOperator Create(Expression.Abstract left, Expression.Abstract right)
		{
			throw new NotImplementedException();
		}

	}
}
