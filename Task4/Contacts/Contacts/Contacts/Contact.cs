using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    public class Contact
    {
        public long ContactNumber {get; set;}
        public string ContactName { get; set;}
        public Contact (long contactNumber, string contactName)
        {
            ContactNumber = contactNumber;
            ContactName = contactName;
        }

        public Contact()
        {
        }
        public override string ToString()
        {
            return string.Format("Contact Name: {0}, contact number {1}", ContactName, ContactNumber);
        }
    }
}
