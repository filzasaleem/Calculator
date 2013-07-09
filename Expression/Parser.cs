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
		public Abstract Parse(string expression)
		{
			return this.Parse(null, Token.Abstract.Tokenize(expression));
		}
		Abstract Parse(Token.Abstract operator1, Collection.IQueue<Token.Abstract> arguments)
		{
			Abstract left;
			Abstract right;
			Token.Abstract operator2 = null; 
			if (operator1.IsNull())
				operator1 = this.PushOnStack(arguments);
			if (operator2.IsNull())
				operator2 = this.PushOnStack(arguments);
			if (arguments.Count > 0)
			{
				if (arguments.Peek() is Token.Number)
					this.stack.Push(new Expression.Number((arguments.Dequeue() as Token.Number).Value));
				else if (arguments.Peek() is Token.Variable)
					this.stack.Push(new Expression.Variable((arguments.Dequeue() as Token.Variable).Name));
			}
			right = this.stack.Pop();
			left = this.stack.Pop();
			if (operator1.NotNull())
			{
				if (operator2.NotNull())
				{
					if (operator1.Precedence < operator2.Precedence)
						this.stack.Push((operator2 as Token.BinaryOperator).Create(left, right));
					else if (operator1.Precedence > operator2.Precedence || operator1.Precedence == operator2.Precedence)
					{
						Abstract temp = this.stack.Pop();
				        this.stack.Push((operator1 as Token.BinaryOperator).Create(temp, left));
				        this.stack.Push(right);
						operator1 = operator2;
					}
					this.Parse(operator1, arguments);
				}
				else
				{
					this.stack.Push((operator1 as Token.BinaryOperator).Create(left, right));
				    operator1 = null;
				}
			}
			return this.stack.Peek();
		}
		public Token.Abstract PushOnStack(Collection.IQueue<Token.Abstract> arguments)
		{
			Token.Abstract result = null;
			if (arguments.Count > 0)
			{
				if (arguments.Peek() is Token.Number)
				{
					this.stack.Push(new Expression.Number((arguments.Dequeue() as Token.Number).Value));
					result = PushOnStack(arguments);
				}
				else if (arguments.Peek() is Token.Variable)
				{
					this.stack.Push(new Expression.Variable((arguments.Dequeue() as Token.Variable).Name));
					result = PushOnStack(arguments);
				}
				else if (arguments.Peek() is Token.BinaryOperator)
					result = arguments.Dequeue();
			}
			return result;
		}
	}
}
