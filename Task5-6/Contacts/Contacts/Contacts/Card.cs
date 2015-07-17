using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    public class Card : IComparable<Card>, ICloneable
    {
        private string _name;
        private long SynCode;

        public Card(long synCode, string name)
        {
            if (synCode <= 0)
            {
                throw new ArgumentException("SynCode не может быть отрицательным или равен нулю.");
            }
            else
                SynCode = synCode;
            
            if (name == string.Empty)
            {
                throw new System.ArgumentNullException("Имя контакта не может быть пустым");
            }
            else
                _name = name;
        }
        public Card()
        {
            SynCode = 1;
            _name = "New project";
        }

        public void ChangeCardSynCode(long newSynCode)
        {
            if (newSynCode > 0)
            {
                SynCode = newSynCode;
            }
            else
                throw new ArgumentException("SynCode не может быть отрицательным или равен нулю.");
        }

        public void ChangeCardName(string name)
        {
            if (name != string.Empty)
            {
                _name = name;
            }
            else
                throw new ArgumentException("Имя контакта не может быть пустым");
        }

        public int CompareTo(Card card)
        {
            if (card == null) return 1;

            Card otherCard = card as Card;
            if (otherCard != null)
                return this.SynCode.CompareTo(otherCard.SynCode);
            else
                throw new ArgumentException("Object is not a Card");

        }
        public object Clone()
        {
            return MemberwiseClone();
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
            return string.Format("Проект {0}, SynCode={1}", _name, SynCode);
        }
        public void ChangeDeletedProject()
        {
            _name = _name + "_DELETED";
        }
        
        public List<string> AddContactToCardList(List<string> CardList)
        {
            var contactName = string.Format("SynCode = {0}, Contact Name = {1}", SynCode, _name);
            CardList.Add(contactName);
            return CardList;
        }
        public string DeleteCard(int id, List<string> CardList)
        {
            string result = "";
            if ((id >= 0) && (id < CardList.Count))
            {
                CardList.RemoveAt(id);
                result = "Контакт удален";
            }
            else
                result = string.Format("Контакт с Id = {0} не найден", id);
            return result;
        }
    }
}
