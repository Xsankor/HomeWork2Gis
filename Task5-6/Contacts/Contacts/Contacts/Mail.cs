using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    public class Mail : Contact
    {
        public string mail { get; set; }

        public Mail(string _mail, string contactName)
        {
            ContactName = contactName;
            mail = _mail;
        }
        public override string ToString()
        {
            return string.Format("Contact - mailto: ({0}), name - {1}", mail, ContactName);
        }
    }
}
