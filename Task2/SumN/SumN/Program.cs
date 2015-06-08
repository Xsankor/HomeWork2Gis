using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество слогаемых - N, где N-целое положительное число");
            uint N=0;
            try
            {
                 N=Convert.ToUInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Введенное значение не соответсвует формату!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            if (N == 0)
            {
                Console.WriteLine("Введенное значение N не должно быть равно нулю!");
                Console.ReadKey();
                Environment.Exit(0);
            }  
            double Sum=0;
            Console.Write("Введите N чисел\n");
            uint i=N;
            try
            {
                while (i > 0)
                {
                    double Number = Convert.ToDouble(Console.ReadLine());
                    Sum = Sum + Number;
                    i--;
                    if (i == 0)
                    {
                        Console.WriteLine("Сумма введенных N чисел = " + Sum);
                        break;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенное значение не соответсвует формату!");
            }
            Console.ReadKey();
        }
    }
}
