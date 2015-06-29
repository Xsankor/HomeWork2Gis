using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    public class Card
    {
        public Dictionary<string, string> CardList = new Dictionary<string, string>();
        public Card()
        {
            CardList.Add("7775545", "Anna Petrova");
            CardList.Add("8884545", "Kit Larson");
            CardList.Add("7898155", "Oleg Ivanov");
        }
        public Card(string number, string name)
        {
            CardList.Add(number, name);
        }
        public string DeleteContact(string number)
        {
            string result = "";
            foreach (var card in CardList)
            {
                if (card.Key == number)
                {
                    CardList.Remove(card.Key);
                    result = "Контакт удален";
                    break;
                }
            }
            if (result != "Контакт удален")
                result = "Такой контакт не найден";
            return result;
        }

        public void ShowAllContacts()
        {
            foreach (var card in CardList)
            {
                Console.WriteLine("Contact number - {0}, concact name - {1}", card.Key, card.Value);
            }
        }

    }
}
