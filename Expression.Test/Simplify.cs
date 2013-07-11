using System;
using NUnit.Framework;


namespace Expression.Test
{
	[TestFixture]
	public class Simplify :
		Kean.Test.Fixture<Simplify>
	{
		protected override void Run()
		{
			this.Run(
				this.AddingConstants,
				this.SubstractingConstants,
				//this.MultiplyingConstants,
				this.DividingConstants,
				this.SineConstants,
				this.PowerOfConstants,
				this.Parsing1,
				this.Parsing2,
				this.Parsing3,
				this.Parsing4,
				this.Parsing5,
				this.Parsing6,
				this.Parsing7,
				this.Parsing8,
				this.Parsing9
				);
		}
		[Test]
		public void AddingConstants()
		{
			Expression.Abstract expression = (Expression.Abstract)2.3f + 1.9f;
			Verify(expression.Simplify(), Is.EqualTo((Expression.Abstract)4.2f));
			expression += 2.56f;

			Verify(expression.Simplify(), Is.EqualTo((Expression.Abstract)6.76f));
		}
		[Test]
		public void SubstractingConstants()
		{
			Expression.Abstract before = -(Expression.Abstract)1.9f - 1.2f;
			Expression.Abstract after = -3.1f;
			Verify(before.Simplify(), Is.EqualTo(after));
		}
		[Test]
		public void MultiplyingConstants()
		{
			Expression.Abstract before = -(Expression.Abstract)9f * -3f;
			Expression.Abstract after = 27f;
			Verify(before.Simplify(), Is.EqualTo(after));
		}
		[Test]
		public void DividingConstants()
		{
			Expression.Abstract before = (Expression.Abstract)(7f * -3f) / 2f;
			Expression.Abstract after = -10.5f;
			Verify(before.Simplify(), Is.EqualTo(after));
		}
		[Test]
		public void PowerOfConstants()
		{
			Expression.Abstract before = (Expression.Abstract)4f ^ 2f;
			Expression.Abstract after = 16f;
			Verify(before.Simplify(), Is.EqualTo(after));
		}
		[Test]
		public void SineConstants()
		{
			Expression.Abstract exp0 = new Expression.Variable("x");
			Expression.Abstract exp1 = new Expression.Variable("y");
			Expression.Abstract befor = new Expression.Sine(exp0 + exp1 + exp0);
			//Expression.Abstract before = new Expression.Sine(Kean.Math.Single.Pi / 2f);
			Expression.Abstract after = new Expression.Sine(2 * exp0 + exp1);
			Verify(befor.Simplify(), Is.EqualTo(after));


		}
		[Test]
		public void Parsing1()
		{
			Expression.Abstract expression = (Expression.Abstract)"2+3";
			Verify(expression, Is.EqualTo((Abstract)2 + 3));
		}
		public void Parsing2()
		{
			Expression.Abstract expression = (Expression.Abstract)"x+y";
			Expression.Abstract variable1 = new Expression.Variable("x");
			Expression.Abstract variable2 = new Expression.Variable("y");
			Verify(expression, Is.EqualTo(variable1 + variable2));
		}
		public void Parsing3()
		{
			Expression.Abstract expression = (Expression.Abstract)"x+2";
			Expression.Abstract variable1 = new Expression.Variable("x");
			Verify(expression, Is.EqualTo(variable1 + 2));
		}
		public void Parsing4()
		{
			Expression.Abstract expression = (Expression.Abstract)"x-2*x-3";
			Expression.Abstract variable1 = new Expression.Variable("x");
			Expression.Abstract correct = variable1 - 2 * variable1 - 3;
			Verify(expression, Is.EqualTo(correct));
		}
		public void Parsing5()
		{
			Expression.Abstract expression = (Expression.Abstract)"x+2*x/3-y";
			Expression.Abstract variable1 = new Expression.Variable("x");
			Expression.Abstract variable2 = new Expression.Variable("y");
			Expression.Abstract correct = variable1 + 2 * variable1 / 3 - variable2;
			Verify(expression, Is.EqualTo(correct));
		}
		public void Parsing6()
		{
			Expression.Abstract expression = (Expression.Abstract)"x+2^y/3-y";
			Expression.Abstract variable1 = new Expression.Variable("x");
			Expression.Abstract variable2 = new Expression.Variable("y");
			Expression.Abstract correct = variable1 + (Abstract)2 ^ variable2 / 3 - variable2;
			Verify(expression, Is.EqualTo(correct));
		}
		public void Parsing7()
		{
			Expression.Abstract expression = (Expression.Abstract)"x+2+y/3-y";
			Expression.Abstract variable1 = new Expression.Variable("x");
			Expression.Abstract variable2 = new Expression.Variable("y");
			Expression.Abstract correct = variable1 + 2 + variable2/ 3 - variable2;
			Verify(expression, Is.EqualTo(correct));
		}
		public void Parsing8()
		{
			Expression.Abstract expression = (Expression.Abstract)"x*2-y/3/y*5/6/65";
			Expression.Abstract variable1 = new Expression.Variable("x");
			Expression.Abstract variable2 = new Expression.Variable("y");
			Expression.Abstract correct = variable1 * 2 - variable2 / 3 / variable2 * (Abstract)5 / (Abstract)6 / (Abstract)65;
			Verify(expression, Is.EqualTo(correct));
		}
		public void Parsing9()
		{
			Expression.Abstract expression = (Expression.Abstract)"-x+-2+y/3-y";
			Expression.Abstract variable1 = new Expression.Variable("x");
			Expression.Abstract variable2 = new Expression.Variable("y");
			Expression.Abstract correct = -variable1 + -(Abstract)2 + variable2 / 3 - variable2;
			Verify(expression, Is.EqualTo(correct));
		}
	}
}
