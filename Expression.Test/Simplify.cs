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
                this.MultiplyingConstants,
                this.DividingConstants,
                this.SineConstants,
                this.PowerOfConstants 
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
            Expression.Abstract before = -(Expression.Abstract) 1.9f - 1.2f;
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
            Expression.Abstract before = (Expression.Abstract) (7f *-3f)/ 2f;
            Expression.Abstract after = -10.5f;
            Verify(before.Simplify(), Is.EqualTo(after));
        }
        [Test]
        public void PowerOfConstants()
        {
            Expression.Abstract before = (Expression.Abstract) 4f^2f;
            Expression.Abstract after = 16f;
            Verify(before.Simplify(), Is.EqualTo(after));
        }
        [Test]
        public void SineConstants()
        {
            Expression.Abstract before = new Expression.Sine(Kean.Math.Single.Pi / 2f);
            Verify(before.Evaluate(), Is.EqualTo(1f));

        }
    }
}
