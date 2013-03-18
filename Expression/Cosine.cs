using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
   public class Cosine:
       Function 
    {
       protected override string Symbol { get { return "cos"; } }
       public Cosine(Abstract argument) : 
           base(argument)
       { }
       public override float Evaluate(params Kean.Core.KeyValue<string, float>[] variables)
       {
           return Kean.Math.Single.Cosinus(this.Argument.Evaluate(variables));
       }
       public override Abstract Derive(string variable)
       {
           return -(new Sine(this.Argument) * this.Argument.Derive(variable));
       }
       
    }
}
