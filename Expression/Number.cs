using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
    public class Number : 
        Abstract
    {
        protected override int Precedence { get { return int.MaxValue; } }

        public float Value { get; private set; }
        public Number(float value)
        {
            this.Value = value;
        }
        public override string ToString()
        {
            return this.Value.ToString();
        }
        public override float Evaluate(params Kean.Core.KeyValue<string, float>[] variables)
        {
            return this.Value;
        }
        public override Abstract Derive(string variable)
        {
            return 0f;
        }
        public override Abstract Simplify()
        {
            return this;
        }
        public override bool Equals(Abstract other)
        {
            return other is Number && Kean.Math.Single.Absolute(this.Value - (other as Number).Value) <= 0.000001f;
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
