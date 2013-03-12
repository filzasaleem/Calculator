using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
   public class Multiplication:
         BinaryOperator
    {
        protected override int Precedence{get {return 1;}}
        protected override string Symbol { get { return "*"; } }
        public override float Evaluate()
        {
            return this.Left.Evaluate() * this.Right.Evaluate();
        }

    }
}
