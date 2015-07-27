﻿using System;
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
            List<Card> CardList = new List<Card>();
            // Заполняем список карточек
            var defaultCard = new Card(118, "Lee Smith");
            defaultCard.AddCardToCardList(CardList, defaultCard);
            defaultCard = new Card(119, "J Stark");
            defaultCard.AddCardToCardList(CardList, defaultCard);
            defaultCard = new Card(120, "John Doe");
            defaultCard.AddCardToCardList(CardList, defaultCard);

            string answer = "";
            for (int i = 0; answer != "0"; i++)
            {
                Console.WriteLine("0. Завершение работы программы\n"
                    + "1. Создать карточку\n"
                    + "2. Изменить карточку, хранящуюся в списке контактов\n"
                    + "3. Добавить контакт к карточке\n"
                    + "4. Удалить контакты у карточки\n"
                    + "5. Удалить карточку, хранящуюся в списке контактов\n"
                    + "6. Вывести все карточки на экран\n"
                    + "7. Добавить контакты в базу");

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
                            //string newContact = string.Empty;
                            switch (answerAddContact)
                            {
                                case "1":
                                    createTelephoneContact(CardList);
                                    break;
                                case "2":
                                    createMailContact(CardList);
                                    break;
                                default:
                                    throw new Exception(string.Format("Невозможно создать контакт, так как введенное значение {0} не равно 1 или 2", answerAddContact));
                            }
                             Console.WriteLine("Контакт добавлен\n");    
                            break;
                        }
                    case "4":
                        {
                            DeleteCardsContact(CardList);
                            break;
                        }
                    case "5":
                        {
                            DeleteContact(CardList);
                            break;
                            
                        }
                    case "6":
                        {
                            var allCards = DisplayAllCards(CardList);
                            Console.WriteLine(allCards + '\n');
                            break;
                        }
                       
                    case "7":
                        {
                            SaveInFile(CardList);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Введенное значение отличается от 1-7!");
                            break;
                        }
                }
            }

        }

        // Метод создания телефонного контакта и добавления его в карточку
        private static string createTelephoneContact(List<Card> cardList)
        {
            try
            {
                Console.WriteLine("Введите Id карточки, к которой хотите добавить контакт");
                long id = System.Convert.ToInt64(Console.ReadLine());
                if ((id >= 1) && (id <= cardList.Count))
                {
                    var cd = new Card();
                    cd = cd.GetCardById(cardList, id);
                    Console.WriteLine("Введите имя контакта");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите код города");
                    long cityCode = System.Convert.ToInt64(Console.ReadLine());
                    var tc = new TelephoneContact(cityCode, name);
                    cd.AddTelephoneContactToCard(tc, cd);
                    return "Контакт добавлен!\n" + tc.ToString();
                }
                else
                    throw new Exception(string.Format("Карточка с Id = {0} не существует", id));
            }

            catch (Exception er)
            {
                return (er.Message);
            }
        }

        // Метод создания новой карточки, которую можно заполнить
        private static void AddCard(List<Card> cardList)
        {
            try
            {
                Console.WriteLine("Введите SynCode карточки:");
                var synCode = System.Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Введите Name карточки:");
                var name = Console.ReadLine();
                var newCard = new Card(synCode, name);
                newCard.AddCardToCardList(cardList, newCard);
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
        private static string DisplayAllCards(List<Card> CardList)
        {
            var contactList = string.Empty;
            foreach (var card in CardList)
            {
                long id = card.GetIdByCard(card);
                long synCode = card.GetSynCodeByCard(card);
                string name = card.GetNameByCard(card);
                contactList = contactList + string.Format("Id карточки - {0}, Name карточки - {1}, SynCode карточки - {2}\n", id, name, synCode);
                if (card.ContactList.Count != 0)
                {
                    int i = 1;
                    foreach(var contact in card.ContactList)
                    {
                        contactList = contactList + string.Format("{0}) {1}", i, contact.ToString()) + '\n';
                        i++;
                    }
                }
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
        private static string createMailContact(List<Card> cardList)
        {
            try
            {
                Console.WriteLine("Введите Id карточки, к которой хотите добавить контакт");
                long id = System.Convert.ToInt64(Console.ReadLine());
                if ((id >= 1) && (id <= cardList.Count))
                {
                    var cd = new Card();
                    cd = cd.GetCardById(cardList, id);
                    Console.WriteLine("Введите имя контакта");
                    string _name = Console.ReadLine();
                    Console.WriteLine("Введите e-mail контакта");
                    string _mail = Console.ReadLine();
                    Mail mc = new Mail(_mail, _name);
                    cd.AddMailContactToCard(mc, cd);
                    return "Контакт создан!\n" + mc.ToString();
                }
                else
                    throw new Exception(string.Format("Карточка с Id = {0} не существует", id));
            }
            catch (Exception er)
            {
                return (er.Message);
            }
        }

        // Метод изменения карточки
        private static void ModifyCard(List<Card> cardList)
        {
            Console.WriteLine("Введите Id карточки, которую хотите изменить");
            try
            {
                long id = System.Convert.ToInt64(Console.ReadLine());
                if ((id >= 0) && (id <= cardList.Count))
                {
                    var cd = new Card();
                    cd = cd.GetCardById(cardList, id);
                    Console.WriteLine("Введите параметр карточки, который хотите изменить - SynCode или Name");
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "Syncode":
                        case "SynCode":
                        case "syncode":
                            {
                                Console.WriteLine("Введите новый SynCode карточки");
                                long newSynCode = System.Convert.ToInt64(Console.ReadLine());
                                cd.ChangeCardSynCode(newSynCode);
                                Console.WriteLine("Карточка изменена");
                                break;
                            }
                        case "Name":
                        case "name":
                            {
                                Console.WriteLine("Введите новое Name карточки");
                                string newName = Console.ReadLine();
                                cd.ChangeCardName(newName);
                                Console.WriteLine("Карточка изменена");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Введенный параметр {0} отсутствует у карточки", answer);
                                break;
                            }
                    }
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

        // Метод удаления карточки
        private static void DeleteContact(List<Card> cardList)
        {
            Console.WriteLine("Введите Id карточки, которую хотите удалить");
            try
            {
                long id = System.Convert.ToInt64(Console.ReadLine());
                var card = new Card();
                var result = card.DeleteCard(id, cardList);
                Console.WriteLine(result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенное значение не соответсвует формату числа!");
                Console.ReadKey();
            }
        }

        // Метод удаления у карточки контактов
        private static void DeleteCardsContact(List<Card> cardList)
        {
            Console.WriteLine("Введите Id карточки, у которой хотите удалить контакты");
            try
            {
                long id = System.Convert.ToInt64(Console.ReadLine());
                if ((id >= 0) && (id <= cardList.Count))
                {
                    var card = new Card();
                    card = card.GetCardById(cardList, id);
                     var contactCount = card.ContactList.Count;
                    if (contactCount == 0)
                    {
                        Console.WriteLine("У карточки с id {0} отсутствуют контакты", id);
                    }
                    else
                    {
                        while (contactCount > 0)
                        {
                            card.ContactList.Remove(card.ContactList[contactCount-1]);
                            contactCount--;
                        }
                        Console.WriteLine("Контакты у карточки с id {0} удалены", id);
                    }
                }
                else
                    throw new Exception(string.Format("Карточка с Id = {0} не существует", id));
                    
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

        // Метод добавления списка карточек в файл contacts.txt
        private static void SaveInFile(List<Card> cardList)
        {
            var allCards1 = DisplayAllCards(cardList);
            var allCards = new List<string>();
            allCards.Add(allCards1);
            string path = "C:\\Temp\\contacts.txt";
            File.AppendAllLines(path, allCards);
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
