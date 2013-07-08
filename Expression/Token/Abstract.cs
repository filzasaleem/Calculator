using System;
using Collection = Kean.Core.Collection;

namespace Expression.Token
{
	public abstract class Abstract
	{
		public abstract int Precedence { get; }
		public static Collection.IQueue<Abstract> Tokenize(string data)
		{
			System.Text.StringBuilder digit = new System.Text.StringBuilder();
			Collection.IQueue<Token.Abstract> arguments = new Collection.Queue<Abstract>();
		    foreach(char c in data)
			{
				if (char.IsDigit(c))
				{
					digit.Append(c);
					continue;
				}
				else if (c == '.')
				{
					digit.Append(c);
					continue;
				}
			    else if(digit.Length > 0)
				{
					arguments.Enqueue(new Token.Number(float.Parse(digit.ToString())));
					digit = new System.Text.StringBuilder();
				}
				if (char.IsLetter(c))
					arguments.Enqueue(new Token.Variable(c.ToString()));
				else
					switch (c)
					{
						case '-':
							arguments.Enqueue(new Token.Subtraction());
							break;
						case '+':
							arguments.Enqueue(new Token.Addition());
							break;
						case '*':
							arguments.Enqueue(new Token.Multiplication());
							break;
						case '/':
							arguments.Enqueue(new Token.Division());
							break;
						case '^':
							arguments.Enqueue(new Token.Power());
							break;
					}
			}
			if (digit.Length > 0)
			{
				arguments.Enqueue(new Token.Number(float.Parse(digit.ToString())));
				digit = new System.Text.StringBuilder();
			}
		    return arguments;
		}
	}
}
