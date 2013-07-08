using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Token
{
	public class Variable :
		Abstract
	{
		public override int Precedence { get { return int.MaxValue; } }
		public string Name { get; private set; }
		public Variable(string name)
		{
			this.Name = name;
		}
		

		//public override bool Equals(Abstract other)
		//{
		//	return other is Variable && this.Name == (other as Variable).Name;
		//}
		//public override int GetHashCode()
		//{
		//	return this.Name.GetHashCode();
		//}
	}
}
