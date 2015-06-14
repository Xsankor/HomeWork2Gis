using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculator2;

namespace Calculator2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение: (между операндами и знаком операции должен быть пробел)");
            string expression = Console.ReadLine();
            string[] splitExpression = expression.Split(' ');
            double Number1 = 0;
            double Number2 = 0;
            double Result;
            try
            {
                Number1 = Convert.ToDouble(splitExpression[0]);
                Number2 = Convert.ToDouble(splitExpression[splitExpression.Length - 1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенное значение не соответсвует формату числа!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            try
            {
                switch (splitExpression[1])
                {
                    case "+":
                        Result = Calculator2.Func.Sum(Number1, Number2);
                        Console.WriteLine("Результат = " + Result);
                        break;
                    case "-":
                        Result = Calculator2.Func.Minus(Number1, Number2);
                        Console.WriteLine("Результат = " + Result);
                        break;
                    case "*":
                        Result = Calculator2.Func.Multiplication(Number1, Number2);
                        Console.WriteLine("Результат = " + Result);
                        break;
                    case "/":
                        if (Number2 != 0)
                        {
                            Result = Calculator2.Func.Devision(Number1, Number2);
                            Console.WriteLine("Результат = " + Result);
                        }
                        else
                            throw new System.DivideByZeroException();
                        break;
                    default:
                        Console.WriteLine("Калькулятор может выполнять только операции: +, -, /, * !");
                        break;
                }
                Console.ReadKey();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Операция деления на 0 не может быть выполнена!");
                Console.ReadKey();
            }
        }

    }
}
