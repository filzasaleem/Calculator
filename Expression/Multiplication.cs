using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
   public class Multiplication:
         BinaryOperator
    {
        protected override int Precedence{get {return 7;}}
        protected override string Symbol { get { return "*"; } }
        public Multiplication(Abstract left, Abstract right) :
           base(left, right)
       { }
        public override float Evaluate(params KeyValue<string, float>[] variables)
        {
            return this.Left.Evaluate(variables) * this.Right.Evaluate(variables);
        }
        public override Abstract Derive(string variable)
        {
            return this.Left.Derive(variable) * this.Right + this.Left * this.Right.Derive(variable);
        }
        public override Abstract Simplify()
        {
            Abstract result;
            Abstract left = this.Left.Simplify();
            Abstract right = this.Right.Simplify();
            if(left == right )
                result = (Abstract)(left ^ 2);
            else if (left is Number && (left as Number).Value == 1)
                result = right ;
            else if(right is Number && (right as Number).Value == 1)
                result = left;
            else if((left is Number && (left as Number).Value == 0)||(right is Number && (right as Number).Value == 0))
                result = 0;
            else 
                result = this ;
            return result;
        }
        public override bool Equals(Abstract other)
        {
            return other is Multiplication && this.Left == (other as Multiplication).Left && this.Right == (other as Multiplication).Right;
        }
        public override int GetHashCode()
        {
            return this.Left.GetHashCode() ^ typeof(Multiplication).GetHashCode() ^ this.Right.GetHashCode();
        }

    }
}
