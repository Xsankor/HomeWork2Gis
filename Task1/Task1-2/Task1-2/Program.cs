using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong Number = 1267165676175383;
            byte TypeId = Convert.ToByte(Number >> 62);
            ulong CityId = Number << 2;
            CityId = CityId >> 49;
            ulong TableId = Number << 17;
            TableId = TableId >> 49;
            ulong ObjectId = Number << 32;
            ObjectId = ObjectId >> 32;
            Console.WriteLine("Id типа: " + TypeId);
            Console.WriteLine("Id города: " + CityId);
            Console.WriteLine("Id таблицы: " + TableId);
            Console.WriteLine("Id записи (объекта): " + ObjectId);
            Console.ReadKey();
        }
    }
}
