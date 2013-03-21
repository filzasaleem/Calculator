using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
    public class Variable :
         Abstract
    {
        protected override int Precedence { get { return int.MaxValue; } }

        public string Name { get; private set; }
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
        public override Abstract Simplify()
        {
            return this;
        }
        public override bool Equals(Abstract other)
        {
            return other is Variable && this.Name == (other as Variable).Name;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }

}
