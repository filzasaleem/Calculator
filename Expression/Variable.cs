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
            float result = 0;
            foreach (KeyValue<string, float> variable in variables)
                if (variable.Key == this.Name)
                    result =  variable.Value;
            return result;

            //return variables.Find(variable => variable.Key == this.Name).Value;
        }
    }
}
