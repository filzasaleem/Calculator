﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
    public abstract class UnaryOperator :
        Abstract
    {
        protected abstract string Symbol { get; }
        public Abstract Argument { get; private set; }

        protected UnaryOperator(Abstract argument)
        {
            this.Argument = argument;
        }
        public override string ToString()
        {
            return this.Symbol + this.Argument.ToString(this.Precedence);
        }
        public override Abstract Derive(string variable)
        {
            throw new NotImplementedException();
        }
        public override Abstract Simplify()
        {
            throw new NotImplementedException();
        }
    }
}
