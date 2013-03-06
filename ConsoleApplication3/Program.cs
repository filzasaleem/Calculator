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
            //Counter c = new Counter();
            //c.Add(3);
            //c.Add(17);
            //Console.WriteLine("total: {0}, average: {1}", c.Value, c.Mean());

            Expression.Abstract expression0 = new Expression.Addition() { Left = new Expression.Number(2.3f), Right = new Expression.Number(1.2f) };
            Expression.Abstract expression1 = new Expression.Addition() { Left = expression0, Right = new Expression.Number(3f) };
            //Console.WriteLine(expression0);
            //Console.WriteLine(expression1 + " = " + expression1.Evaluate());


            Expression.Abstract expression2 = new Expression.Subtraction() { Left = new Expression.Number(2.3f), Right = new Expression.Number(1.2f) };
//            Expression.Abstract expression3 = new Expression.Subtraction() { Left = expression2, Right = new Expression.Number(0.1f) };
            Expression.Abstract expression3 = expression1 - 0.1f - expression1;
           // Console.WriteLine(expression2);
            Console.WriteLine(expression3 + " = " + expression3.Evaluate());
            Console.ReadKey();
        }
    }

}
