using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    class Program
    {
        Dictionary<long, string> CardList = new Dictionary<long, string> 
        {
            {1, "SynCode = 123, Contact Name = Anna Petrova"},
            {2, "SynCode = 103, Contact Name = J Stark"}
        };
        static void Main(string[] args)
        {
            Dictionary<long, string> CardList = new Dictionary<long, string> 
            {
                {1, "SynCode = 123, Contact Name = Anna Petrova"},
                {2, "SynCode = 103, Contact Name = J Stark"}
            };
            string answer = "";
            long NextId = 3; 
            for (int i = 0; answer != "0"; i++)
            {
                Console.WriteLine("Для создания телефонного контакта и его сохранения в текущей сессии, введите-1\n"
                + "Для создания e-mail контакта введите и его сохранения в текущей сессии- 2\n"
                + "Для завершения работы программы, нажмите 0\n");
                answer = Console.ReadLine();

                switch (answer)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        try
                        {
                            Console.WriteLine("Введите имя контакта");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите код города");
                            long cityCode = System.Convert.ToInt64(Console.ReadLine());
                            TelephoneContact tc = new TelephoneContact(cityCode, name);
                            Console.WriteLine(tc.ToString());
                            Console.WriteLine("Вывести список всех контактов? (1 - Да, любая другая клавиша - нет)");
                            string ans = Console.ReadLine();
                            if (ans == "1")
                            {
                                string cardNumber = tc.ZoneCode.ToString();
                                string cardName = tc.ContactName;
                                Card cd = new Card(NextId, tc.ZoneCode, tc.ContactName);
                                cd.AddContactToCardList(CardList);
                                NextId++;
                                Console.WriteLine(cd.ShowAllContacts(CardList));
                                Console.WriteLine("Вы хотите удалить последний контакт? (1 - Да, любая другая клавиша - нет)");
                                string ansDelete = Console.ReadLine();
                                if (ansDelete == "1")
                                { 
                                    // В программе напрямую указала на созданный контакт, но можно поменять на то, 
                                    //чтобы пользователь сам вводил, какой контакт ему нужно удалить
                                    Console.WriteLine(cd.DeleteContact(NextId-1, CardList));
                                    Console.WriteLine(cd.ShowAllContacts(CardList));
                                }
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Введенное значение не соответсвует формату числа!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        break;

                    case "2":
                        try
                        {
                            Console.WriteLine("Введите имя контакта");
                            string _name = Console.ReadLine();
                            Console.WriteLine("Введите e-mail контакта");
                            string _mail = Console.ReadLine();
                            Mail mc = new Mail(_mail, _name);
                            Console.WriteLine(mc.ToString());
                            Console.WriteLine("Вывести список всех контактов? (1 - Да, любая другая клавиша - нет)");
                            string ans = Console.ReadLine();
                            if (ans == "1")
                            {
                                var cardName = "(mailto: "+ mc.mail.ToString() + ") " + mc.ContactName;
                                Card cd = new Card(NextId, 0, cardName);
                                cd.AddContactToCardList(CardList);
                                NextId++;
                                Console.WriteLine(cd.ShowAllContacts(CardList));
                                Console.WriteLine("Вы хотите удалить последний контакт? (1 - Да, любая другая клавиша - нет)");
                                string ansDelete = Console.ReadLine();
                                if (ansDelete == "1")
                                {
                                    // В программе напрямую указала на созданный контакт, но можно поменять на то, 
                                    //чтобы пользователь сам вводил, какой контакт ему нужно удалить
                                    Console.WriteLine(cd.DeleteContact(NextId - 1, CardList));
                                    Console.WriteLine(cd.ShowAllContacts(CardList));
                                }
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Введенное значение не соответсвует формату числа!");
                            Console.ReadKey();
                        }
                        break;

                    default:
                        Console.WriteLine("Введенное значение отличается от 1, 2!");
                        break;
                }
            }
        }
    }
}
