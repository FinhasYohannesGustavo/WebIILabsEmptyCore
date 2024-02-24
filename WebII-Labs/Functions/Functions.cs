using Microsoft.AspNetCore.Mvc.Formatters;
using System.Diagnostics.CodeAnalysis;

namespace WebII_Labs.Functions
{
    public class Functions
    {
        public static Func<int, int> square = x => x * x;

        /*Here I am going to create a generic function that can accept as parameter any type*/
        public static void  customSwapper<AnyType>(ref AnyType a, ref AnyType b)
        {
            AnyType temp = a;
            a = b;
            b = temp;
        }
        public static double Square(double x)
        {
            return x * x;
        }
        public static int Square(int x)
        {
            return x * x;
        }

        public static double SquareDouble(int x)
        {
            double y = x * x;

            return y;
        }

        public delegate TOutput customFunc<in T,out TOutput>(T inputVar);

        customFunc<int,int> squarecustom = Square;

    }
}
