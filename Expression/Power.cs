using System;
using Kean.Core;
using Kean.Core.Extension;
namespace Expression
{
   public class Power:
       BinaryOperator 
    {
       protected override int Precedence {get {return 3; } }
       protected override string Symbol { get { return "^"; } }
       
       public Power(Abstract left, Abstract right) :
           base(left, right)
       { }

       public override float Evaluate(params Kean.Core.KeyValue<string, float>[] variables)
       {
           return Kean.Math.Single.Power(this.Left.Evaluate(variables), this.Right.Evaluate(variables));
       }
       public override Abstract Derive(string variable)
       {
           return this.Right * this.Left ^ (this.Right - 1) * this.Left.Derive(variable);
       }
       public override Abstract Simplify()
       {
           Abstract result;
           Abstract left = this.Left.Simplify();
           Abstract right = this.Right.Simplify();
           if (left is Number && (left as Number).Value == 0)
               result = 0;
           else if ((left is Number && (left as Number).Value == 1) || (right is Number && (right as Number).Value == 0))
               result = 1;
           else if(right is Number &&( right as Number).Value == 1)
               result = left;
           else if((right is Number) && (left is Number ))
               result = Kean.Math.Single.Power((right as Number).Value , (left as Number).Value);
           else
               result = this;
           return result;
       }
       public override bool Equals(Abstract other)
       {
           return other is Power && this.Left == (other as Power).Left && this.Right == (other as Power).Right;
       }
       public override int GetHashCode()
       {
           return this.Left.GetHashCode() ^ typeof(Power).GetHashCode() ^ this.Right.GetHashCode();
       }
    }
}
