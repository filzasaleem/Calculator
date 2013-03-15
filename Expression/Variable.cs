using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
   public class Variable:
        Abstract 
    {
         protected override int Precedence { get { return int.MaxValue; } }

        public string Name { get; set; }
        public Variable(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return this.Name;
        }

        public override float Evaluate(params KeyValue<string, float>[] variables)
        {
            return variables.Find(variable => variable.Key == this.Name).Value;
        }
        public override Abstract Derive(string variable)
        {
            return variable == this.Name ? 1 : 0;
        }

    }
}
