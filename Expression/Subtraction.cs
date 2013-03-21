using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
    public class Subtraction:
       BinaryOperator
    {
        protected override int Precedence { get { return 5; } }
        protected override string Symbol { get { return "-"; } }
         public Subtraction(Abstract left, Abstract right) : 
           base(left,right)
       { }
        public override float Evaluate(params KeyValue<string, float>[] variables)
        {
            return this.Left.Evaluate(variables) - this.Right.Evaluate(variables);
        }
        public override Abstract Derive(string variable)
        {
           return this.Left.Derive(variable) - this.Right.Derive(variable);
        }
        public override Abstract Simplify()
        {
            Abstract result;
            Abstract left = this.Left.Simplify();
            Abstract right = this.Right.Simplify();
            if (left == right)
                result = 0;
            else if(left is Number &&(left as Number).Value == 0)
                result = right ;
            else if(right is Number &&(right as Number).Value == 0)
                result = left;
            else
                result = this;
            return result;
        }
        public override bool Equals(Abstract other)
        {
            return other is Subtraction  && this.Left == (other as Subtraction ).Left && this.Right == (other as Subtraction ).Right;
        }
        public override int GetHashCode()
        {
            return this.Left.GetHashCode() ^ typeof(Subtraction).GetHashCode() ^ this.Right.GetHashCode();
        }

    }
}
