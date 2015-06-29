using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Card firstCard = new Card();
            Card secondCard = new Card(3, 8, "Second_project");
            firstCard.ChangeProjectId();
            firstCard.GetProjectName();
            Console.WriteLine(firstCard.GetProjectInfo());
            secondCard.ChangeProjectId();
            secondCard.GetProjectName();
            Console.WriteLine(secondCard.GetProjectInfo());
            secondCard.ChangeDeletedProject();
            Console.WriteLine(secondCard.GetProjectInfo());
            Console.ReadKey();
        }
    }
}
