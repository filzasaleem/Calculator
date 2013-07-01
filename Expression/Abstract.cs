using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
    public abstract class Abstract :
        IEquatable<Abstract>
    {
       
        protected abstract int Precedence { get; }
        //public abstract bool ContainsVariables { get; }
        public float Evaluate()
        {
            return this.Evaluate(new KeyValue<string, float>[0]);
        }

        public abstract float Evaluate(params KeyValue<string, float>[] variables);
        public abstract Abstract Derive(string variable);
        public abstract Abstract Simplify();

        internal string ToString(int precedence)
        {
            string result = this.ToString();
            if (precedence > this.Precedence)
                result = "(" + result + ")";
            return result;
        }
        #region Equality
        public override bool Equals(object other)
        {
            return this.Equals(other as Abstract);
        }
        public abstract bool Equals(Abstract other);

        public static bool operator ==(Abstract left, Abstract right)
        {
            return left.Same(right) || left.NotNull() && left.Equals(right);
        }
        public static bool operator !=(Abstract left, Abstract right)
        {
            return !left.Same(right) && (left.IsNull() || !left.Equals(right));
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        public static Subtraction operator -(Abstract left, Abstract right)
        {
            return new Subtraction(left, right);
        }
        public static Addition operator +(Abstract left, Abstract right)
        {
            return new Addition(left, right);
        }
        public static Multiplication operator *(Abstract left, Abstract right)
        {
            return new Multiplication(left, right);
        }
        public static Division operator /(Abstract left, Abstract right)
        {
            return new Division(left, right);
        }
        public static Modulo operator %(Abstract left, Abstract right)
        {
            return new Modulo(left, right);
        }
        public static Power operator ^(Abstract left, Abstract right)
        {
            return new Power(left, right);
        }
        public static Negation operator -(Abstract argument)
        {
            return new Negation(argument);
        }

        public static implicit operator Abstract(float value)
        {
            return new Number(value);
        }
		public static implicit operator Abstract(char value)
        {
            string temp = value.ToString();
            return new Variable(temp);
        }
        public static explicit operator Abstract(string expression)
        {
			return new Parser().Parse(expression);
        }
		
    }
}
