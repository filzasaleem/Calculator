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

        public float Value { get; set; }
        public Number(float value)
        {
            this.Value = value;
        }
        public override string ToString()
        {
            return this.Value.ToString();
        }

        public override float Evaluate()
        {
            return this.Value;
        }
    }
}
