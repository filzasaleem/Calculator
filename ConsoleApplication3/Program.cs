using System;
using Kean.Core;
using Kean.Core.Extension;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression.Abstract f = new Expression.Variable("x") ^ 2f;
            Console.WriteLine("d/dx(" + f + ") = " + f.Derive("x"));
            Expression.Abstract l = new Expression.Sine(new Expression.Variable("x"));
            Console.WriteLine("d/dx(" + l + ") =" + l.Derive("x"));
            Expression.Abstract expression8 = -(new Expression.Variable("i"));
            Console.WriteLine(expression8 + "=" + expression8.Evaluate(KeyValue.Create("i", 2.9f)));



            //Expression.Abstract expression0 = new Expression.Variable("x") + new Expression.Variable("y");
            //Expression.Abstract expression1 = expression0 + new Expression.Variable("x");
            Expression.Abstract expression9 = new Expression.Sine(new Expression.Variable("j"));
            //Expression.Abstract expression10 = new Expression.Cosine(new Expression.Variable("j"));
            //Expression.Abstract expression2 = new Expression.Variable("z") - new Expression.Variable("y");
            //Expression.Abstract expression3 = new Expression.Variable("y") * new Expression.Variable("z");
            //Expression.Abstract expression4 = new Expression.Variable("z") / (new Expression.Variable("x") * 2.4f);
            //Expression.Abstract expression5 = new Expression.Variable("y") % new Expression.Variable("z");
            //Expression.Abstract expression6 = -expression1 - expression3 * expression4 - 0.1f - expression5 - expression9 + expression10+ expression4  - expression1;
            //Expression.Abstract expression7 = (Expression.Abstract)2.3f + 1.9f - 1.2f + (Expression.Abstract)0.8f / 2.3f;
          
            //Console.WriteLine(expression6 + " = " + expression6.Evaluate(KeyValue.Create("x", 3.1415f), KeyValue.Create("y", 4.2f),KeyValue.Create("z",5.2f),KeyValue.Create("i",30f)));
            //Console.WriteLine(expression7);
            Expression.Abstract expression11 = new Expression.Variable("x");
            Expression.Abstract expression12 = (Expression.Abstract)5f + 6f + (expression11 + expression11 + -expression11) + 2 * -expression11 + new Expression.Variable("filza");
            //Expression.Abstract expression12 = (expression11 / expression11) + ((0 ^ expression11) + (1 * expression11) + (expression11 - expression11 + expression11)) + ((expression11 / expression11) + ((Expression.Abstract)5f + 6f)) + (expression9 + expression9);
            Console.WriteLine(expression12);
            Console.WriteLine(expression12.Simplify());
           // Console.WriteLine(expression12.Simplify().Simplify());
            Console.ReadKey();
        }
    }

}
