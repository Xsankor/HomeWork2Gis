using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Contacts
{
    public abstract class Contact : IComparable<Contact>
    {
        public string ContactName { get; set;}
        public Contact (string contactName)
        {
            ContactName = contactName;
        }

        public Contact()
        {
        }
        public int CompareTo(Contact ct) 
        {
            if (ct == null) return 1;

            Contact otherCt = ct as Contact;
            if (otherCt != null)
                return this.ContactName.CompareTo(otherCt.ContactName);
            else
                throw new NullReferenceException("Object is not a Contact");
        }
        public override string ToString()
        {
            return string.Format("Contact Name: {0}", ContactName);
        }
        
        public XElement ToXml()
        {
            XElement xmlContact = new XElement("Contacts", new XAttribute("Name", ContactName));
            return xmlContact;
        }

    }
}
