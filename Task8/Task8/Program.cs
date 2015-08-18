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
            int[] mas = { 1, 2, 4, 5, 3 , 6, 8};
            mas.OrderBy(n => n);
            Console.WriteLine(mas.Print('-'));
            Console.ReadKey();
        }
    }
}
