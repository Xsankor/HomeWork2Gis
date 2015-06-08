using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 7;
            int[,] Matrix1 = new int[N, N];
            int[,] Matrix2 = new int[N, N];
            int[,] MatrixResult = new int[N, N];
            string StrMatrix1 = "Первая матрица: \n", StrMatrix2 = "Вторая матрица: \n", StrResult = "Результат: \n";
            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Matrix1[i, j] = rand.Next(100);
                    Matrix2[i, j] = rand.Next(100);
                    MatrixResult[i, j] = Matrix1[i, j] + Matrix2[i, j];
                    StrMatrix1 = StrMatrix1 + Matrix1[i, j] + '\t';
                    StrMatrix2 = StrMatrix2 + Matrix2[i, j] + '\t';
                    StrResult = StrResult + MatrixResult[i, j] + '\t';
                    if (j == 6)
                    {
                        StrMatrix1 = StrMatrix1 + '\n';
                        StrMatrix2 = StrMatrix2 + '\n';
                        StrResult = StrResult + '\n';
                    }
                }

            }
            Console.WriteLine(StrMatrix1);
            Console.WriteLine(StrMatrix2);
            Console.WriteLine(StrResult);
            Console.ReadKey();
        }
           
    }
}
