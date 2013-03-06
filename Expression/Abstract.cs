using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
    public abstract class Abstract
    {
        protected abstract int Precedence { get; }

        public abstract float Evaluate();

        //public abstract float Evaluate(params KeyValuePair<string, float>[] variables);
        //public abstract Abstract Derive(string variable);

        internal string ToString(int precedence)
        {
            string result = this.ToString();
            if (precedence > this.Precedence)
                result = "(" + result + ")";
            return result;
        }

        public static Subtraction operator -(Abstract left, Abstract right)
        {
            return new Subtraction() { Left = left, Right = right };
        }

        public static implicit operator Abstract(float value)
        {
            return new Number(value);
        }

        public static explicit operator Abstract(string expression)
        {
            // add parsing here
            return null;
        }

    }
}
