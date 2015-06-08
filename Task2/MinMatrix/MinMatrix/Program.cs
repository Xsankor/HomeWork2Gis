using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 7;
            int[,] Matrix = new int[N, N];
            Random rand = new Random();
            string Result = "Минимальные значения в каждой страке: \n";
            string StrMatrix = "Матрица: \n";
            for (int i = 0; i < N; i++)
            {
                int[] LocalArray = new int[N];
                for (int j = 0; j < N; j++)
                {
                    Matrix[i, j] = rand.Next(100);
                    LocalArray[j] = Matrix[i, j];
                    StrMatrix = StrMatrix + Matrix[i, j] + '\t';
                    if (j == 6)
                    {
                        Array.Sort(LocalArray);
                        Result = Result + LocalArray[0] + '\n';
                        StrMatrix = StrMatrix + '\n';
                    }
                }
            }
            Console.WriteLine(StrMatrix);
            Console.WriteLine(Result);
            Console.ReadKey();
    
        }
    }
}
