using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double Number1 = 0, Number2 = 0, Result;
            string MathOperator = "";
            Console.WriteLine("Введите первое число");
            try
            {
                Number1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите математический оператор");
                MathOperator = Console.ReadLine();
                Console.WriteLine("Введите второе число");
                Number2 = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенное значение не соответсвует формату числа!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            try
            {
                switch (MathOperator)
                {
                    case "+":
                        Result = Number1 + Number2;
                        Console.WriteLine("Результат = " + Result);
                        break;
                    case "-":
                        Result = Number1 - Number2;
                        Console.WriteLine("Результат = " + Result);
                        break;
                    case "*":
                        Result = Number1 * Number2;
                        Console.WriteLine("Результат = " + Result);
                        break;
                    case "/":
                        if (Number2 != 0)
                        {
                            Result = Number1 / Number2;
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
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Операция деления на 0 не может быть выполнена!");
                Console.ReadKey();
            }

        }
    }
}
