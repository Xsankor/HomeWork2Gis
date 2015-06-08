using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degree
{
    class Program
    {
        static void Main(string[] args)
        {
            double Number = 0, Degree = 0, Result = 0;
            Console.WriteLine("Введите X - число, которое хотите возвести в степень");
            try 
            {
                Number = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите N - степень, в которую хотите возвести число");
                Degree = Convert.ToDouble(Console.ReadLine());
                Result = Math.Pow(Number, Degree);
                if (Convert.ToString(Result) == "NaN")
                {
                    Console.WriteLine("Данную операцию невозможно выполнить. Результат - не определен!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Х в степени N = " + Result);
                    Console.ReadKey();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенное значение не соответствует формату числа!");
                Console.ReadKey();
            }
        }
    }
}
