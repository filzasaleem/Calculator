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
        public override float Evaluate(params KeyValue<string, float>[] variables)
        {
            return this.Left.Evaluate(variables) / this.Right.Evaluate(variables);
        }
        public override Abstract Derive(string variable)
        {
            return (this.Left.Derive(variable) * this.Right - this.Left * this.Right.Derive(variable)) / this.Right ^ 2;
        }
    }
}
