using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            var regFloat = new Regex(@"[-+]?\d+\.\d*");
            string str = "10, 15, -18.01, 65, -3";
            var firstFloat = regFloat.Match(str);
            if (firstFloat.Success)
            {
                Console.WriteLine(firstFloat.Groups[0]);
            }

            var regData = new Regex(@"\d\d\s[a-z][a-z][a-z]\s\d\d\d\d*", RegexOptions.IgnoreCase);
            str = "First 20 Nov 2016, second 05 Dec 2016";
            var dates = regData.Matches(str);
            foreach (Match data in dates)
            {
                Console.WriteLine(data.Value);
                
            }
            Console.ReadKey();

            var Path = "B:\\F";
            DirectoryInfo mainDirectory = new DirectoryInfo(Path);
            DeleteDirectory(mainDirectory);

            
        }

        private static long GetNextFibbonachiNumber(long Number)
        {
            if (Number == 0)
                return 0;
            if (Number == 1)
                return 1;
            else
                return GetNextFibbonachiNumber(Number - 1) + GetNextFibbonachiNumber(Number - 2);
        }

        // Рекурсивное удаление директории
        private static void DeleteDirectory(DirectoryInfo mainDirectory)
        {
            if (!mainDirectory.Exists)
                return;
            var directories = mainDirectory.EnumerateDirectories();
            foreach (var directory in directories)
            {
                DeleteDirectory(directory);
            }
            mainDirectory.Delete(true);
        }
    }
}
