using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Sum
    {
        static void Main(string[] args)
        {
            // Задание: Ввести с консоли числа вывести их сумму
            Console.WriteLine("Введите первое число");
            string a = Console.ReadLine();
            Console.WriteLine("Введите второе число");           
            string b = (Console.ReadLine());
            try
            {
                double FirstNumber = Convert.ToDouble(a);
                double SecondNumber = Convert.ToDouble(b);
                double Result;
                Result = FirstNumber + SecondNumber;
                Console.WriteLine("Сумма: " + Result);
            }
            catch { Console.WriteLine("Ошибка! Можно вводить вводить только числа"); }
            Console.ReadKey();
        }
    }
}
