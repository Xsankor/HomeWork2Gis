using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    public class Card
    {
        private string _name;
        private long SynCode;
        private long Id;
        public Card(long id, long synCode, string name)
        {
            Id = id;
            SynCode = synCode;
            _name = name;
        }
        public Card()
        {
            Id = 0;
            SynCode = 1;
            _name = "New project";
        }
        public long ChangeProjectId()
        {
            if ((Id == 0) || (Id - SynCode != 100))
                Id = SynCode + 100;
            return Id;
        }
        public string GetProjectName()
        {
            if (_name != "New project")
            {
                _name = _name + Convert.ToString(SynCode);
            }
            else
            {
                _name = "Project" + Convert.ToString(SynCode);
            }
            return _name;
        }

        public string GetProjectInfo()
        {
            return string.Format("Проект {0}, id={1}, SynCode={2}", _name, Id, SynCode);
        }
        public void ChangeDeletedProject()
        {
            _name = _name + "_DELETED";
        }

        public Dictionary<long, string> AddContactToCardList(Dictionary<long, string> CardList)
        {
            var contactName = string.Format("SynCode = {0}, Contact Name = {1}", _name, SynCode);
            CardList.Add(Id, contactName);
            return CardList;
        }
        public string DeleteContact(long id, Dictionary<long, string> CardList)
        {
            string result = "";
            foreach (var card in CardList)
            {
                if (card.Key == id)
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

        public string ShowAllContacts(Dictionary<long, string> CardList)
        {
            var contactList = string.Empty;
            foreach (var card in CardList)
            {
                contactList = contactList + string.Format("Contact number - {0}, concact name - {1}", card.Key, card.Value);
            }
            return contactList;
        }
    }
}
