using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Contacts
{
    public class Card : IComparable<Card>, ICloneable
    {
        private string _name;
        private long SynCode;
        private long Id;
        public List<Contact> ContactList = new List<Contact>();
        public CardStatus cardStatus;

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

            cardStatus = CardStatus.Verifyed;
        }

        public Card()
        {
            SynCode = 1;
            _name = "New project";
            cardStatus = CardStatus.Verifyed;
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
                throw new ArgumentNullException("Имя контакта не может быть пустым");
        }

        public int CompareTo(Card card)
        {
            if (card == null) return 1;

            Card otherCard = card as Card;
            if (otherCard != null)
                return this.SynCode.CompareTo(otherCard.SynCode);
            else
                throw new System.NullReferenceException("Object is not a Card");
        }

        public object Clone()
        {
            Card newCard = (Card)this.MemberwiseClone();
            newCard.ContactList = new List<Contact>(this.ContactList);
            return newCard;
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

        public long GenerateCardId(long number)
        {
            Id = number + 1;
            return Id;
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


        public CardStatus LoadCardStatus(string statusValue)
        {
            Enum.TryParse(statusValue, true, out cardStatus);
            return cardStatus;
        }

        public XElement ToXml()
        {
            XElement xmlCard = new XElement("Card",
                new XElement("Id",
                    new XAttribute("Value", Id)),
                new XElement("SynCode",
                    new XAttribute("Value", SynCode)),
                new XElement("Name",
                    new XAttribute("Value", _name)), 
                new XElement("CardStatus", 
                    new XAttribute("Status", cardStatus)));
            return xmlCard;
        }

    }
}
