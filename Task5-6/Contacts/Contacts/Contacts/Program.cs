using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Contacts;

namespace Contacts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> CardList = new List<string>
            {
                "SynCode = 123, mailto: (testLe@mail.ru), Contact Name = Lee Smith",
                "SynCode = 103, Contact Name = J Stark",
                "SynCode = 189, mailto: (testDoe@mail.ru), Contact Name = John Doe"
            };

            string answer = "";
            for (int i = 0; answer != "0"; i++)
            {
                Console.WriteLine("0. Завершение работы программы\n"
                    + "1. Создать карточку\n"
                    + "2. Изменить карточку, хранящуюся в списке контактов\n"
                    + "3. Добавить контакт к карточке\n"
                    + "4. Удалить карточку, хранящуюся в списке контактов\n"
                    + "5. Вывести все карточки на экран\n"
                    + "6. Добавить контакты в базу");

                answer = Console.ReadLine();
                switch (answer)
                {
                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case "1":
                        {
                            AddCard(CardList);
                            break;
                        }
                    case "2":
                        {
                            ModifyCard(CardList);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(
                                "1. Создать телефонный контакт;\n"
                                + "2. Создать mail контакт\n");
                            var answerAddContact = Console.ReadLine();
                            string newContact = string.Empty;
                            switch (answerAddContact)
                            {
                                case "1":
                                    newContact = createTelephoneCard(CardList);
                                    break;
                                case "2":
                                    newContact = createMailCard(CardList);
                                    break;
                                default:
                                    throw new Exception(string.Format("Невозможно создать контакт, так как введенное значение {0} не равно 1 или 2", answerAddContact));
                            }
                             Console.WriteLine(newContact + '\n');    
                            break;
                        }
                    case "4":
                        {
                            DeleteContact(CardList);
                            break;
                            
                        }
                    case "5":
                        {
                            var allCards = DisplayAllCards(CardList);
                            Console.WriteLine(allCards + '\n');
                            break;
                        }
                    case "6":
                        {
                            SaveInFile(CardList);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введенное значение отличается от 1-6!");
                            break;
                        }
                }
            }

        }

        // Метод создания телефонного контакта и добавления его в карточку
        private static string createTelephoneCard(List<string> cardList)
        {
            try
            {
                var cd = createCard();
                Console.WriteLine("Введите имя контакта");
                string name = Console.ReadLine();
                Console.WriteLine("Введите код города");
                long cityCode = System.Convert.ToInt64(Console.ReadLine());
                var tc = new TelephoneContact(cityCode, name);
                cd.ChangeCardName(name);
                cd.ChangeCardSynCode(cityCode);
                cd.AddContactToCardList(cardList);
                return "Контакт создан!\n" + tc.ToString();
            }

            catch (Exception er)
            {
                return (er.Message);
            }
        }

        // Метод создания новой карточки, которую можно заполнить
        private static void AddCard(List<string> cardList)
        {
            try
            {
                Console.WriteLine("Введите SynCode карточки:");
                var synCode = System.Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Введите Name карточки:");
                var name = Console.ReadLine();
                var newCard = new Card(synCode, name);
                newCard.AddContactToCardList(cardList);
                Console.WriteLine("Карточка добавлена.");
            }
            catch (ArgumentNullException anEr)
            {
                Console.WriteLine(anEr.Message);
            }
            catch (ArgumentException aEr)
            {
                Console.WriteLine(aEr.Message);
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }

        }

        // Метод вывода всех контактов
        private static string DisplayAllCards(List<string> CardList)
        {
            var contactList = string.Empty;
            int i = 0;
            foreach (var card in CardList)
            {
                contactList = contactList + string.Format("Contact id - {0}, {1}\n", i, card);
                i++;
            }
            return contactList;
        }

        // Метод создания карточки, вызывается незаполненная форма
        private static Card createCard()
        { 
            var newCard = new Card();
            return newCard;
        }

        // Метод создания mail контакта
        private static string createMailCard(List<string> cardList)
        {
            try
            {
                var cd = createCard();
                Console.WriteLine("Введите имя контакта");
                string _name = Console.ReadLine();
                Console.WriteLine("Введите e-mail контакта");
                string _mail = Console.ReadLine();
                Mail mc = new Mail(_mail, _name);
                cd.ChangeCardName(string.Format("mailto: ({0}), Contact Name - {1}", _mail, _name));
                cd.AddContactToCardList(cardList);
                return "Контакт создан!\n" + mc.ToString();
            }
            catch (Exception er)
            {
                return (er.Message);
            }
        }

        // Метод изменения карточки
        private static void ModifyCard(List<string> cardList)
        {
            Console.WriteLine("Введите Id карточки, которую хотите изменить");
            try
            {
                int id = System.Convert.ToInt32(Console.ReadLine());
                if ((id >= 0) && (id < cardList.Count))
                {
                    Console.WriteLine("Введите новое значение карточки");
                    var newValue = Console.ReadLine();
                    if (newValue != string.Empty)
                    {
                        cardList[id] = Console.ReadLine();
                        Console.WriteLine("Карточка изменена");
                    }
                    else 
                        throw new Exception("Имя контакта не может быть пустым");
                }

                else
                    throw new Exception(string.Format("Контакт с Id = {0} не существует", id));
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенное значение не соответсвует формату числа!");
                Console.ReadKey();
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
        }

        //Метод удаления карточки
        private static void DeleteContact(List<string> cardList)
        {
            Console.WriteLine("Введите Id карточки, которую хотите удалить");
            try
            {
                int id = System.Convert.ToInt32(Console.ReadLine());
                var emptyCard = new Card();
                var result = emptyCard.DeleteCard(id, cardList);
                Console.WriteLine(result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенное значение не соответсвует формату числа!");
                Console.ReadKey();
            }
        }

        // Метод добавления списка карточек в файл contacts.txt
        private static void SaveInFile(List<string> cardList)
        {
            string path = "C:\\Temp\\contacts.txt";
            File.AppendAllLines(path, cardList);
            Console.WriteLine("Список контактов, хранящихся в базе:");

            StreamReader sr = new StreamReader(path);

            try
            {
                string text = sr.ReadToEnd();
                Console.WriteLine(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Dispose();
            }

        }
    }
}
