using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter three values for Addition");
            Expression.Abstract expression0 = new Expression.Addition() { Left = new Expression.Number(float.Parse(Console.ReadLine())), Right = new Expression.Number(float.Parse(Console.ReadLine())) };
            Expression.Abstract expression1 = new Expression.Addition() { Left = expression0, Right = new Expression.Number(float.Parse(Console.ReadLine())) };
            Console.WriteLine("enter 2 values for Subtraction");
            Expression.Abstract expression2 = new Expression.Subtraction() { Left = new Expression.Number(float.Parse(Console.ReadLine())), Right = new Expression.Number(float.Parse(Console.ReadLine())) };
            Console.WriteLine("enter 2 values for Multiplication");
            Expression.Abstract expression3 = new Expression.Multiplication() { Left = new Expression.Number(float.Parse(Console.ReadLine())), Right = new Expression.Number(float.Parse(Console.ReadLine())) };
            Console.WriteLine("enter 2 values for Division");
            Expression.Abstract expression4 = new Expression.Division() { Left = new Expression.Number(float.Parse(Console.ReadLine())), Right = new Expression.Number(float.Parse(Console.ReadLine())) };

            Expression.Abstract expression5 = expression1 - expression3 - 0.1f - expression4  - expression1;
          
            Console.WriteLine(expression5 + " = " + expression5.Evaluate());
            Console.ReadKey();
        }
    }

}
