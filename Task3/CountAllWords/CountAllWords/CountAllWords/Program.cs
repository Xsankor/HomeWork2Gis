using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountAllWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            Console.WriteLine("введите текст");
            text = Console.ReadLine();
            char[] textSymbols = text.ToCharArray();
            int countWords = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (i > 0)
                {
                    // В данном выражении при подсчете мы исключаем эти подсимволы, т.к. они могут находиться отделенными от текста пробелами.
                    if ((textSymbols[i-1] == '-') || (textSymbols[i-1] == '"'))
                    {
                        continue;
                    }
                    if ((textSymbols[i] == ' ') && (textSymbols[i-1] != ' '))
                    {
                        countWords++;
                    }
                    if ((i == text.Length - 1) && (textSymbols[i] != ' '))
                    {
                         countWords++;
                    }
                }
            }
            Console.WriteLine("Количество слов в тексте: " + countWords);
            Console.ReadKey();
        }
    }
}
