using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
   public class Division:
       BinaryOperator 
    {
        protected override int Precedence { get { return 8; } }
        protected override string Symbol { get { return "/"; } }
        public Division(Abstract left, Abstract right) :
           base(left, right)
       { }

        public override float Evaluate(params KeyValue<string, float>[] variables)
        {
            return this.Left.Evaluate(variables) / this.Right.Evaluate(variables);
        }
        public override Abstract Derive(string variable)
        {
            return (this.Left.Derive(variable) * this.Right - this.Left * this.Right.Derive(variable)) / this.Right ^ 2;
        }
        public override Abstract Simplify()
        {
           // Abstract result=0;
            Abstract left = this.Left.Simplify();
            Abstract right = this.Right.Simplify();
			return (left * (right^-1)).Simplify();
			//if (left == right)
			//	result = 1;
			//else if (left is Number && (left as Number).Value == 0)
			//	result = 0;
			//else if ((left is Negation) && (left as Negation).Argument == right)
			//	result = -1;
			//else if (left is Multiplication)
			//{
			//	if ((left as Multiplication).Right == right)
			//		result = (left as Multiplication).Left;
			//	else if ((left as Multiplication).Left == right)
			//		result = (left as Multiplication).Right;
			//	else if ((left as Multiplication).Right is Number && (left as Multiplication).Left is Number && right is Number)
			//		result = (((left as Multiplication).Right as Number).Value * ((left as Multiplication).Left as Number).Value) / right;
			//}
			//else if (left is Number && right is Number)
			//	result = (left as Number).Value / (right as Number).Value;
			//else
			//	result = this;

			//return result;
        }
        public override bool Equals(Abstract other)
        {
            return other is Division && this.Left == (other as Division).Left && this.Right == (other as Division).Right;
        }
        public override int GetHashCode()
        {
            return this.Left.GetHashCode() ^ typeof(Division).GetHashCode() ^ this.Right.GetHashCode();
        }
    }
}
