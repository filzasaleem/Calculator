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
		public Abstract Result { get; set; }
		Collection.IQueue<object> arguments;
		char token = '\0' ;
		public Abstract Parse(string expression)
		{
			this.arguments  = new Tokenizer().Tokenize(expression);
			this.Result = ParseExpression(arguments);
			return this.Result;

		}
		public Abstract ParseExpression(Collection.IQueue<object> arguments)
		
		{
			Abstract expression1;
			Abstract expression2;
			expression1 = ParseFactor(arguments);
			if (arguments.Count != 0)
			{
				if(token == '\0')
				   token = (char)arguments.Dequeue();
				if (token == '+')
				{
					expression2 = ParseExpression(arguments);
					expression1 += expression2;
					if (token == '+')
					  token = '\0';
				}
				else if (token == '-')
				{
					expression2 = ParseExpression(arguments);
					expression1 -= expression2;
					if (token == '-')
					  token = '\0';
				}
			}
			return expression1;
		}
		public Abstract ParseFactor(Collection.IQueue<object> arguments)
		{
			Abstract expression1;
			Abstract expression2;
			expression1 = ParseValue(arguments);
			if (arguments.Count != 0)
			{
				if (token == '\0')
					token = (char)arguments.Dequeue();
				if (token == '*')
				{
					expression2 = ParseFactor(arguments);
					expression1 *= expression2;
					if(token == '*')
					  token = '\0';
				}
				else if(token == '/')
				{
					expression2 = ParseFactor(arguments);
					expression1 /= expression2;
					if (token == '/')
					  token = '\0';
				}
				else if (token == '%')
				{
					expression2 = ParseFactor(arguments);
					expression1 %= expression2;
					if (token == '%')
						token = '\0';
				}
				else if (token == '^')
				{
					expression2 = ParseFactor(arguments);
					expression1 ^= expression2;
					if (token == '^')
						token = '\0';
				}
			}
			return expression1;
		}
		public Abstract ParseValue(Collection.IQueue<object> arguments)
		{
			Abstract expression1 = null;
			if(arguments.Count != 0)
			{
				token = (char)arguments.Dequeue();
				if (char.IsDigit(token))
				{
					expression1 = (Abstract)float.Parse(token.ToString());
					token = '\0';
					return expression1;
				}
				else if (char.IsLetter(token))
				{
					expression1 = (Abstract)token;
					token = '\0';
					return expression1;
				}
				else if (token == '(')
				{
					expression1 = ParseExpression(arguments);
					token = '\0';
					return expression1;
				}
				else if (token == ')')
				{
					token = '\0';
					expression1 = token;
				}
			}
			return expression1;
		}
		class Tokenizer
		{
		    Collection.IQueue<object> arguments;
			public Collection.IQueue<object> Tokenize(string expression)
			{
				this.arguments = new Collection.Queue<object>();
				foreach (char c in expression)
				{
					if (char.IsDigit(c) || char.IsLetter(c) || c == '-' || c == '*' || c == '/' || c == '%' || c == '+' || c == '(' || c == ')' || c == '^')
						this.arguments.Enqueue(c);
				}
				return this.arguments;
			}
		}
	}
}
