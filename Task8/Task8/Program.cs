using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(ArrayExtensions.Print(mas, '\n'));
            Console.ReadKey();
        }
    }
}
