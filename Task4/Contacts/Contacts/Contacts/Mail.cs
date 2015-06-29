using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    public class Mail : Contact
    {
        public string mail { get; set; }

        public Mail(long contactNumber, string _mail, string contactName)
        {
            ContactName = contactName;
            ContactNumber = contactNumber;
            mail = _mail;
        }
        public override string ToString()
        {
            return string.Format("Contact - mailto: ({0})-{1}, name - {2}", mail, ContactNumber, ContactName);
        }
    }
}
