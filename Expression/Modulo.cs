﻿using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
   public  class Modulo:
        BinaryOperator 
    {
        protected override int Precedence { get { return 6; } }
        protected override string Symbol{ get { return "%"; } }
        public Modulo(Abstract left, Abstract right) :
           base(left, right)
       { }
        public override float Evaluate(params KeyValue<string, float>[] variables)
        {
            return this.Left.Evaluate(variables) % this.Right.Evaluate(variables);
        }
        public override Abstract Derive(string variable)
        {
            throw new NotImplementedException();
        }
        public override Abstract Simplify()
        {
            Abstract result;
            Abstract left = this.Left.Simplify();
            Abstract right = this.Right.Simplify();
            if (left == right)
                result = 0;
            else if (left is Number && (left as Number).Value == 0)
                result = 0;
            else
                result = this;
            return result;
        }
        public override bool Equals(Abstract other)
        {
            return other is Modulo  && this.Left == (other as Modulo).Left && this.Right == (other as Modulo).Right;
        }
        public override int GetHashCode()
        {
            return this.Left.GetHashCode() ^ typeof(Modulo).GetHashCode() ^ this.Right.GetHashCode();
        }
    }
}
