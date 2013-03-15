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
       public override float Evaluate(params Kean.Core.KeyValue<string, float>[] variables)
       {
           return Kean.Math.Single.Power(this.Left.Evaluate(variables), this.Right.Evaluate(variables));
       }
       public override Abstract Derive(string variable)
       {
           return this.Right * this.Left ^ (this.Right - 1) * this.Left.Derive(variable);
       }
    }
}
