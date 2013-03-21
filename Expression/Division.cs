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
            Abstract result;
            Abstract left = this.Left.Simplify();
            Abstract right = this.Right.Simplify();
            if (left == right)
                result = 1;
            else if(left is Number && (left as Number).Value == 0)
                result = 0;
            else 
            result = this;
            return result;
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
