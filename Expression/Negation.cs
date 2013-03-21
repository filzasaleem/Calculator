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
         public Negation(Abstract argument) : 
           base(argument)
       { }
        public override float Evaluate(params KeyValue<string, float>[] variables)
        {
            return -this.Argument.Evaluate(variables);
        }
        public override Abstract Simplify()
        {
            return new Negation (this.Argument.Simplify());
        }
        public override bool Equals(Abstract other)
        {
            return other is Negation  && this.Argument == (other as Negation).Argument;
        }
        public override int GetHashCode()
        {
            return this.Argument.GetHashCode() ^ typeof(Negation).GetHashCode();
        }
}
    
}
