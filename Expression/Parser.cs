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
		public Abstract Parse(string expression)
		{
			return this.Parse(null,Token.Abstract.Tokenize(expression));
		}
		Abstract Parse(Token.Abstract @operator, Collection.IQueue<Token.Abstract> arguments)
		{
			Abstract left;
			Abstract right;
			if(@operator == null)
				@operator = PushOnStack(arguments);
			if (this.token == null)
				this.token = PushOnStack(arguments);
			if (arguments.Count > 0)
			{
				if (arguments.Peek() is Token.Number)
				{
					Abstract number = new Expression.Number((arguments.Dequeue() as Token.Number).Value);
					this.stack.Push(number);
				}
				else if (arguments.Peek() is Token.Variable)
				{
					Abstract name = new Expression.Variable((arguments.Dequeue() as Token.Variable).Name);
					this.stack.Push(name);
				}
			}
			right = this.stack.Pop();
			left = this.stack.Pop();
			if (@operator != null && this.token != null && @operator.Precedence < this.token.Precedence)
			{
				this.stack.Push((this.token as Token.BinaryOperator).Create(left, right));
				this.token = null;
				Parse(@operator, arguments);
			}
			else if ((@operator != null && this.token != null) && (@operator.Precedence > this.token.Precedence || @operator.Precedence == this.token.Precedence))
			{
				Abstract temp = this.stack.Pop();
				this.stack.Push((@operator as Token.BinaryOperator).Create(temp, left));
				this.stack.Push(right);
				@operator = this.token;
				this.token = null;
				Parse(@operator, arguments);
			}
			else if (@operator != null && this.token == null)
			{
				this.stack.Push((@operator as Token.BinaryOperator).Create(left, right));
				@operator = null;
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
					Abstract number = new Expression.Number((arguments.Dequeue() as Token.Number).Value);
					this.stack.Push(number);
					result = PushOnStack(arguments);
				}
				else if (arguments.Peek() is Token.Variable)
				{
					Abstract name = new Expression.Variable((arguments.Dequeue() as Token.Variable).Name);
					this.stack.Push(name);
					result = PushOnStack(arguments);
				}
				else if (arguments.Peek() is Token.BinaryOperator)
					result = arguments.Dequeue();
			}
			return result;
		}
	}
}
