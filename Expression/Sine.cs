using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
    public class Sine:
        Function 
    {
        
        protected override string Symbol { get { return "sin"; } }
        public Sine(Abstract argument) :
            base(argument)
        { }
        public override float Evaluate(params Kean.Core.KeyValue<string, float>[] variables)
        {
            return Kean.Math.Single.Sinus(this.Argument.Evaluate(variables));
        }
        public override Abstract Derive(string variable)
        {
            return new Cosine(this.Argument) * this.Argument.Derive(variable);
        }
       
    }
}
