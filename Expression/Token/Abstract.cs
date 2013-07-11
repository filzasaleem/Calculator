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
			bool flag = false;
			foreach (char c in data)
			{
				if (char.IsDigit(c))
					digit.Append(c);
				else if (c == '.')
					digit.Append(c);
				else
				{
					if (digit.Length > 0)
					{
						arguments.Enqueue(new Token.Number(float.Parse(digit.ToString())));
						digit = new System.Text.StringBuilder();
						flag = false;
					}
					if (char.IsLetter(c))
					{
						arguments.Enqueue(new Token.Variable(c.ToString()));
						flag = false;
					}
					else
						switch (c)
						{
							case '-':
								{

									if (flag || arguments.Empty)
										arguments.Enqueue(new Token.Negation());
									else
									{
										arguments.Enqueue(new Token.Subtraction());
										flag = true;
									}
									break;
								}
							case '+':
								arguments.Enqueue(new Token.Addition());
								flag = true;
								break;
							case '*':
								arguments.Enqueue(new Token.Multiplication());
								flag = true;
								break;
							case '/':
								arguments.Enqueue(new Token.Division());
								flag = true;
								break;
							case '^':
								arguments.Enqueue(new Token.Power());
								flag = true;
								break;
							case '(':
								arguments.Enqueue(new Token.LeftParanthesis());
								flag = true;
								break;
							case ')':
								arguments.Enqueue(new Token.RightParanthesis());
								break;
						}
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
