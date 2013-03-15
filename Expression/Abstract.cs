using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
    public abstract class Abstract
    {
        protected abstract int Precedence { get; }

        public float Evaluate()
        {
            return this.Evaluate(new KeyValue<string, float>[0]);
        }

        public abstract float Evaluate(params KeyValue<string, float>[] variables);
        public abstract Abstract Derive(string variable);

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
        public static Addition operator +(Abstract left, Abstract right)
        {
            return new Addition() { Left = left, Right = right };
        }
        public static Multiplication operator *(Abstract left, Abstract right)
        {
            return new Multiplication() { Left = left, Right = right };
        }
        public static Division operator /(Abstract left, Abstract right)
        {
            return new Division() { Left = left, Right = right };
        }
        public static Modulo operator %(Abstract left, Abstract right)
        {
            return new Modulo() { Left = left, Right = right };
        }
        public static Power operator ^(Abstract left, Abstract right)
        {
            return new Power() { Left = left, Right = right };
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
