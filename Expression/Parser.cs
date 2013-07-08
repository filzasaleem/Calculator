using System;
using Kean.Core;
using Kean.Core.Extension;
using Collection = Kean.Core.Collection;

namespace Expression
{
	public class Parser
	{
	    public Parser()
	    {
		}
		Collection.IStack<Abstract> stack = new Collection.Stack<Abstract>();
		Token.Abstract token = null ;
		Token.Abstract operator1 = null;
		Token.Abstract operator2 = null;
		public Abstract Parse(string expression)
		{
			return this.Parse(Token.Abstract.Tokenize(expression));
		}
		Abstract Parse(Collection.IQueue<Token.Abstract> arguments)
		{
			Abstract left;
			Abstract right;
			ParseNumber(arguments);
			if (arguments.Count > 0 && this.operator1 == null)
			{
				this.token = arguments.Dequeue();
				this.operator1 = this.token;
				this.token = null;
			}
			ParseNumber(arguments);
			if (arguments.Count > 0  && this.operator2 == null)
			{
				if (this.token == null)
					this.token = arguments.Dequeue();
				this.operator2 = this.token;
				this.token = null;
			}
			ParseNumber(arguments);
			if (operator1 != null && operator2 != null && operator1.Precedence < this.operator2.Precedence)
			{
				right = this.stack.Pop();
				left = this.stack.Pop();
				this.stack.Push((this.operator2 as Token.BinaryOperator).Create(left, right));
				this.operator2 = null;
				Parse(arguments);
			}
			else if (operator1 != null && operator2 != null  && operator1.Precedence > this.operator2.Precedence)
			{
				Abstract temp = this.stack.Pop();
				right = this.stack.Pop();
				left = this.stack.Pop();
				this.stack.Push((this.operator1 as Token.BinaryOperator).Create(left, right));
				this.stack.Push(temp);
				operator1 = this.operator2;
				this.operator2 = null;
				Parse(arguments);
			}
			else if (operator1 != null && operator2 != null && operator1.Precedence == this.operator2.Precedence)
			{
				Abstract temp = this.stack.Pop();
				right = this.stack.Pop();
				left = this.stack.Pop();
				this.stack.Push((this.operator1 as Token.BinaryOperator).Create(left, right));
				this.stack.Push(temp);
				this.operator2 = null;
				Parse(arguments);
			}
			else if (operator1 != null && this.operator2 == null)
			{
				right = this.stack.Pop();
				left = this.stack.Pop();
				this.stack.Push((this.operator1 as Token.BinaryOperator).Create(left, right));
				operator1 = null;
			}
		   return this.stack.Peek();
		}
		public void ParseNumber(Collection.IQueue<Token.Abstract> arguments)
		{
			if (arguments.Count > 0 && this.token == null)
			{
				this.token = arguments.Dequeue();
				if (this.token is Token.Number)
				{
					Abstract number = new Expression.Number((this.token as Token.Number).Value);
					this.stack.Push(number);
					this.token = null;
				}
				else if (this.token is Token.Variable)
				{
					Abstract name = new Expression.Variable((this.token as Token.Variable).Name);
					this.stack.Push(name);
					this.token = null;
				}
				if (this.token is Token.BinaryOperator && this.operator2 == null)
				{
					this.operator2 = this.token;
					this.token = null;
					ParseNumber(arguments);
				}
			}
		}
	}
}
