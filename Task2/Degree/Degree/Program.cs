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
            double number = 0;
            double degree = 0;
            double result = 0;
            Console.WriteLine("Введите X - число, которое хотите возвести в степень");
            try 
            {
                number = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите N - степень, в которую хотите возвести число");
                degree = Convert.ToDouble(Console.ReadLine());
                result = Math.Pow(number, degree);
                if (Convert.ToString(result) == "NaN")
                {
                    Console.WriteLine("Данную операцию невозможно выполнить. Результат - не определен!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Х в степени N = " + result);
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
