using System;
using Kean.Core;
using Kean.Core.Extension;
using Collection = Kean.Core.Collection;
using Kean.Core.Collection.Extension;

namespace Expression
{
   public class Multiplication:
         BinaryOperator
    {
        protected override int Precedence{get {return 7;}}
        protected override string Symbol { get { return "*"; } }
        public Multiplication(Abstract left, Abstract right) :
           base(left, right)
       { }
        public override float Evaluate(params KeyValue<string, float>[] variables)
        {
            return this.Left.Evaluate(variables) * this.Right.Evaluate(variables);
        }
        public override Abstract Derive(string variable)
        {
            return this.Left.Derive(variable) * this.Right + this.Left * this.Right.Derive(variable);
        }
        public override Abstract Simplify()
        {
			Collection.IList<Tuple<float, Abstract>> terms = this.CollectTerms(this);
			Abstract result;
			float number = 1;
			terms.Remove(term =>
			{
				bool r;
				if (r = term.Item2 is Number)
				{
						number *= (term.Item2 as Number).Value;
				}
				return r;
			});
			result = number;
			while (terms.Count > 0)
			{
				Tuple<float, Abstract> nextItem = terms.Remove();
				Abstract next = nextItem.Item2;
				float repitition = nextItem.Item1;
				terms.Remove(term =>
				{
					bool r;
					if (r = ((term.Item2).Equals(next)))
					{
						repitition += term.Item1;
					}
					return r;
				});
				if (result == 1)
				{

					if (repitition == 1)
						result = next;
					else if (repitition == 0)
						result = 1;
					else
						result = next ^ repitition;
				}
				else
				{
					if (repitition == 1)
						result *= next;
					else if (repitition == 0)
						result = result;
					else
						result *= next ^ repitition;
				}
			}
			return result;
		}

		Collection.IList<Tuple<float, Abstract>> CollectTerms(Abstract current)
		{
			Collection.IList<Tuple<float, Abstract>> result = new Collection.Linked.List<Tuple<float, Abstract>>();
			if (current is Multiplication)
			{
				result.Add(this.CollectTerms((current as Multiplication).Left));
				result.Add(this.CollectTerms((current as Multiplication).Right));
			}
			else if (current is Division)
			{
				result.Add(this.CollectTerms((current as Division).Left));
				result.Add(this.CollectTerms((current as Division).Right));//.Map(term => Tuple.Create(-term.Item1, term.Item2)));
			}
			else
			{
				//current = current.Simplify();
				//if (current is Multiplication && (current as Multiplication).Left is Number)
				//	result.Add(Tuple.Create(((current as Multiplication).Left as Number).Value, (current as Multiplication).Right));
				//else if (current is Division)
				//{
				//	current = current.Simplify();
				//	result.Add(Tuple.Create(1f, current));
				//}
				//else if (current is Negation)
				//	result.Add(Tuple.Create(-1f, (current as Negation).Argument));
				 if (current is Power)
				{
					current = current.Simplify();
					Abstract variable = (current as Power).Left;
					float value = ((current as Power).Right as Number).Value;
					result.Add(Tuple.Create(value, variable));
				}
				else
					result.Add(Tuple.Create(1f, current));
			}
			return result;

		}


			//Abstract result= 0;
			//Abstract left = this.Left.Simplify();
			//Abstract right = this.Right.Simplify();
			//if (right is Number)
			//{
			//	if (left is Number)
			//	{
			//		result = (right as Number).Value * (left as Number).Value;
			//	}
			//	else if ((right as Number).Value == 0)
			//		result = 0;
			//	else if ((right as Number).Value == 1)
			//		result = left;
			//	else
			//	{
			//		Abstract temprorary = right;
			//		left = right;
			//		right = temprorary;
			//		result = left * right;
			//	}
			//}
			//else
			//{
			//	if (left == right)
			//		result = (Abstract)(left ^ 2);
			//	else if (left is Number && (left as Number).Value == 1)
			//		result = right;
			//	else if ((left is Number && (left as Number).Value == 0))
			//		result = 0;
			//	else if (right is Negation)
			//		result = (-left).Simplify() * (right as Negation).Argument;
			//	else if ((left is Negation) && (right is Negation))
			//		result = (left as Negation).Argument * (right as Negation).Argument;
			//	else if (left is Power)
			//	{
			//		if ((left as Power).Left == right)
			//			result = (left as Power).Left ^ 3;
			//		else
			//			result = left * right;
			//	}
			//	else
			//		result = this;
			//}
			//return result;
        
        public override bool Equals(Abstract other)
        {
            return other is Multiplication && this.Left == (other as Multiplication).Left && this.Right == (other as Multiplication).Right;
        }
        public override int GetHashCode()
        {
            return this.Left.GetHashCode() ^ typeof(Multiplication).GetHashCode() ^ this.Right.GetHashCode();
        }

    }
}

