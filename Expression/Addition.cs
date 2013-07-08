using System;
using Kean.Core;
using Kean.Core.Extension;
using Collection = Kean.Core.Collection;
using Kean.Core.Collection.Extension;

namespace Expression
{
    public class Addition :
        BinaryOperator
    {
        protected override int Precedence { get { return 5; } }
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
            Collection.IList<Tuple<float, Abstract>> terms = this.CollectTerms(this);
            Abstract result;
            float number = 0;
            terms.Remove(term =>
            {
                bool r;
                if (r = term.Item2 is Number)
                {
                    if( term.Item1 == -1)
                       number -= (term.Item2 as Number).Value;
                    else
                       number += (term.Item2 as Number).Value;
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
                        repitition += term.Item1;

                    return r;
                });
                if (result == 0)
                {
                    if (repitition == -1)
                        result = -next;
                    else if (repitition == 1)
                        result = next;
                    else
                        result = repitition * next;
                }
                else
                {
                    if (repitition == -1)
                        result -= next;
                    else if (repitition == 1)
                        result += next;
                    else
                        result += repitition * next;
                }
            }
            //Abstract result = this.Left + this.Right;
            //if (result is Addition)
            //{
            //    Abstract left = (result as Addition).Left.Simplify();
            //    Abstract right = (result as Addition).Right.Simplify();
            //    if (left.Equals(right))
            //        result = 2 * left;
            //    else if (left is Number && (left as Number).Value == 0)
            //        result = right;
            //    else if (right is Number && (right as Number).Value == 0)
            //        result = left;
            //    else if (left is Number && right is Number)
            //        result = (left as Number).Value + (right as Number).Value;
            //    else
            //        result = left + right;
            //}
            return result;
        }
        Collection.IList<Tuple<float, Abstract>> CollectTerms(Abstract current)
        {
            Collection.IList<Tuple<float, Abstract>> result = new Collection.Linked.List<Tuple<float, Abstract>>();
            if (current is Addition)
            {
                result.Add(this.CollectTerms((current as Addition).Left));
                result.Add(this.CollectTerms((current as Addition).Right));
            }
            else if (current is Subtraction)
            {
                result.Add(this.CollectTerms((current as Subtraction).Left));
                result.Add(this.CollectTerms((current as Subtraction).Right).Map(term => Tuple.Create(-term.Item1, term.Item2)));
            }
            //else if (current is Division)
            //{
            //    result.Add(this.CollectTerms((current as Division).Left));
            //    result.Add(this.CollectTerms((current as Division).Right));
            //}

            else
            {
                
                current = current.Simplify();
                if (current is Multiplication && (current as Multiplication).Left is Number)
                    result.Add(Tuple.Create(((current as Multiplication).Left as Number).Value, (current as Multiplication).Right));
                else if (current is Division)
                {
                    current = current.Simplify();
                    result.Add(Tuple.Create(1f, current));
                }
                else if (current is Negation)
                    result.Add(Tuple.Create(-1f, (current as Negation).Argument));
                else if (current is Power)
                {
                    current = current.Simplify();
                    result.Add(Tuple.Create(1f, current));
                }
                else
                    result.Add(Tuple.Create(1f, current));
            }
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
