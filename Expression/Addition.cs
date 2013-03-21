using System;
using Kean.Core;
using Kean.Core.Extension;

namespace Expression
{
    public class Addition :
        BinaryOperator
    {
        protected override int Precedence { get { return 4; } }
        protected override string Symbol { get { return "+"; } }
        public Addition(Abstract left, Abstract right) :
           base(left, right)
       { }
        public override float Evaluate(params KeyValue<string, float>[] variables)
        {
            return this.Left.Evaluate(variables) + this.Right.Evaluate(variables);
        }
        public override Abstract Derive(string variable)
        {
            return this.Left.Derive(variable) + this.Right.Derive(variable);
        }
        public override Abstract Simplify()
        {
            Abstract result;
            Abstract left = this.Left.Simplify();
            Abstract right = this.Right.Simplify();
            if (left.Equals(right))
                result = 2 * left;
            else if (left is Number && (left as Number).Value == 0)
                result = right;
            else if (right is Number && (right as Number).Value == 0)
                result = left;
            else if (left is Number && right is Number)
                result = (left as Number).Value + (right as Number).Value;
            else
                result = left + right;
            return result;
        }
        public override bool Equals(Abstract other)
        {
            return other is Addition && this.Left == (other as Addition).Left && this.Right == (other as Addition).Right ;
        }
        public override int GetHashCode()
        {
            return this.Left.GetHashCode() ^ typeof(Addition).GetHashCode() ^ this.Right.GetHashCode();
        }
    }
}
