using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
    public class Addition :
        BinaryOperator
    {
        protected override int Precedence { get { return 4; } }
        protected override string Symbol { get { return "+"; } }
        public override float Evaluate(params KeyValue<string, float>[] variables)
        {
            return this.Left.Evaluate(variables) + this.Right.Evaluate(variables);
        }
        public override Abstract Derive(string variable)
        {
            return this.Left.Derive(variable) + this.Right.Derive(variable);
        }
   }
}
