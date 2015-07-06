using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    public class Contact
    {
        public string ContactName { get; set;}
        public Contact (string contactName)
        {
            ContactName = contactName;
        }

        public Contact()
        {
        }
        public override string ToString()
        {
            return string.Format("Contact Name: {0}", ContactName);
        }
    }
}
