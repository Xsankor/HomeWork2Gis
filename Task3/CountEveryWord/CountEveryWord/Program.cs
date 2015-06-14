using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountEveryWord
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание: Подсчитать количество вхождения каждого слова в тексте и вывести на экран
            Console.WriteLine("Введите текст");
            string text = Console.ReadLine();
            //Список разделителей
            string [] splitWords = text.Split
                (new Char [] {' ', '.', ',', '!', '?', ';', ':'} );
            Array.Sort(splitWords);
            Dictionary<string, string> oneWord =
                new Dictionary<string, string>();

            for (int i = 0, j = 0, k = 0; i < splitWords.Length; )
            {
                if (j < splitWords.Length)
                {
                    if (splitWords[i] == "")
                    {
                        i++;
                        continue;

                        if (i == splitWords.Length)
                        {
                            break;
                        }
                    }
                    bool distinction = false;
                    int[] countOfWord = new int[splitWords.Length];
                    var count = 1;
                    j = i + 1;
                    var difference = 0;
                    while (distinction == false)
                    {
                        try
                        {
                            difference = String.Compare(splitWords[i], splitWords[j]);
                        }
                        catch
                        {
                            countOfWord[k] = 1;
                            oneWord.Add(splitWords[i], Convert.ToString(countOfWord[k]));
                            i = splitWords.Length;
                            break;
                        }
                        if (difference == 0)
                        {
                            count++;
                            if (j == splitWords.Length - 1)
                            {
                                countOfWord[k] = count;
                                oneWord.Add(splitWords[i], Convert.ToString(countOfWord[k]));
                                i = splitWords.Length;
                                break;
                            }
                            if (j + 1 < splitWords.Length)
                            {
                                j++;
                            }
                        }
                        else
                        {
                            countOfWord[k] = count;
                            oneWord.Add(splitWords[i], Convert.ToString(countOfWord[k]));
                            distinction = true;
                            k++;
                            if (j == splitWords.Length - 1)
                            {
                                countOfWord[k] = 1;
                                oneWord.Add(splitWords[j], Convert.ToString(countOfWord[k]));
                                i = splitWords.Length;
                                break;
                            }
                            i = j;
                            j++;
                        }
                    }
                }
            }
            foreach( KeyValuePair <string, string> ow in oneWord )
            {
                Console.WriteLine("Слово = {0}\t Количество вхождений = {1}\t", 
                    ow.Key, ow.Value);
            }
            Console.ReadKey();
        }
    }
}
