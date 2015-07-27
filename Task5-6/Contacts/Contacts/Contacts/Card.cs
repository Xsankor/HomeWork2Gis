using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Contacts
{
    public class Card : IComparable<Card>, ICloneable
    {
        private string _name;
        private long SynCode;
        private long Id;
        public List<Contact> ContactList = new List<Contact>();

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
        
        
        public List<Card> AddCardToCardList(List<Card> CardList, Card newCard)
        {
            newCard.Id = CardList.Count + 1;
            CardList.Add(newCard);
            return CardList;
        }

        public Card AddMailContactToCard(Mail mailContact, Card card)
        {
            card.ContactList.Add(mailContact);
            return card;
        }

        public Card AddTelephoneContactToCard(TelephoneContact telephoneContact, Card card)
        {
            card.ContactList.Add(telephoneContact);
            return card;
        }

        public Card GetCardById(List<Card> cardList, long id)
        {
            return (from c in cardList where c.Id == id select c).FirstOrDefault();
        }

        public long GetIdByCard(Card card)
        {
            return card.Id;
        }

        public string GetNameByCard(Card card)
        {
            return card._name;
        }

        public long GetSynCodeByCard(Card card)
        {
            return card.SynCode;
        }

        public string DeleteCard(long id, List<Card> CardList)
        {
            string result = "";
            if ((id >= 0) && (id <= CardList.Count))
            {
                Card deletedCard = GetCardById(CardList, id);
                CardList.Remove(deletedCard);
                result = "Контакт удален";
            }
            else
                result = string.Format("Контакт с Id = {0} не найден", id);
            return result;
        }

        public XElement ToXml()
        {
            XElement xmlCard = new XElement("Card", 
                new XElement("Id", 
                    new XAttribute("Value", Id)),
                new XElement("SynCode", 
                    new XAttribute("Value", SynCode)),
                new XElement("Name",
                     new XAttribute("Value", _name)));
            return xmlCard;
        }

    }
}
