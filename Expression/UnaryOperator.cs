using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
    public abstract class UnaryOperator:
        Abstract 
    {
        protected abstract string Symbol{get;}
        public Abstract Argument {get;set;}
        public override string ToString()
        {
            return this.Symbol + this.Argument.ToString(this.Precedence);
        }
        public override Abstract Derive(string variable)
        {
            throw new NotImplementedException();
        }
    }
}
