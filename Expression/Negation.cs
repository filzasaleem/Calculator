using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
    public class Negation:
       UnaryOperator 
    {
        protected override int Precedence { get { return 9; } }
        protected override string Symbol { get { return "-"; } }
        public override float Evaluate(params KeyValue<string, float>[] variables)
        {
            return -this.Argument.Evaluate(variables);
        }
    }
}
