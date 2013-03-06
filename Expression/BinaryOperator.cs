using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
   public abstract class BinaryOperator :
       Abstract 
    {
        protected abstract string Symbol { get; }

        public Abstract Left { get; set; }
        public Abstract Right { get; set; }

        public override string ToString()
        {
            return this.Left.ToString(this.Precedence - 1) + " " + this.Symbol + " " + this.Right.ToString(this.Precedence);
        }
    }
}
