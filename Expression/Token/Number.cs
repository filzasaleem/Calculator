using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Token
{
	public class Number :
		Abstract
	{
		public override int Precedence { get { return int.MaxValue; } }
		public float Value { get; private set; }
		public Number(float value)
		{
			this.Value = value;
		}
		

		//public override bool Equals(Abstract other)
		//{
		//	return other is Number && Kean.Math.Single.Absolute(this.Value - (other as Number).Value) <= 0.000001f;
		//}
		//public override int GetHashCode()
		//{
		//	return this.Value.GetHashCode();
		//}
	}
}
