using System;
using NUnit.Framework;


namespace Expression.Test
{
    [TestFixture]
    class SimplifyVariables:
         Kean.Test.Fixture<SimplifyVariables>
    {
        protected override void Run()
        {
            this.Run(
                this.Addition,
                this.Subtraction,
                this.Multiplication,
				this.Division
                );
        }

        [Test]
        public void Addition()
        {
            Expression.Abstract exp0 = new Expression.Variable("x");
            Expression.Abstract exp1 = new Expression.Variable("y");
            Expression.Abstract before = 2*exp0 + exp1 + exp0;
            Expression.Abstract after = 3*exp0 + exp1  ;
            Verify(before.Simplify(), Is.EqualTo(after));
        }
        [Test]
        public void Subtraction()
        {
            Expression.Abstract exp0 = new Expression.Variable("x");
            Expression.Abstract exp1 = new Expression.Variable("y");
            Expression.Abstract before = 2 * exp0 - exp0 - exp1;
            Expression.Abstract after =  -exp1 + exp0  ;
            Verify(before.Simplify(), Is.EqualTo(after));
        }
        [Test]
        public void Multiplication()
        {
            Expression.Abstract exp0 = new Expression.Variable("x");
            Expression.Abstract exp1 = new Expression.Variable("y");
            Expression.Abstract exp2 = new Expression.Variable("z");
			//Expression.Abstract before = exp0 * (exp0 ^ 2) * exp0;
			//Expression.Abstract after = 3 * exp0;
			//Verify(before.Simplify(), Is.EqualTo(after));
        }
		[Test]
		public void Division()
		{
			Expression.Abstract exp0 = new Expression.Variable("x");
			Expression.Abstract exp1 = new Expression.Variable("y");
			Expression.Abstract exp2 = new Expression.Variable("z");
			Expression.Abstract before = exp0*exp1 / exp0;
			Expression.Abstract after = 3 * exp0;
			Verify(before.Simplify(), Is.EqualTo(after));
		}



    }
}
