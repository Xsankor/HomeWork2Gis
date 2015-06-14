using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculator2;

namespace Calculator2
{
    class Func
    {
        //Математические функции
        public static double Sum (double a, double b)
        {
            double result = 0;
            result= a + b;
            return result;
        }
        public static double Minus (double a, double b)
        {
            double result;
            result = a - b;
            return result;
        }
        public static double Multiplication (double a, double b)
        {
            double result;
            result = a * b;
            return result;
        }
        public static double Devision (double a, double b)
        {
            double result;
            result = a / b;
            return result;
        }
    }
}
