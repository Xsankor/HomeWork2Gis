using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    public class TelephoneContact : Contact
    {
        public long ZoneCode {get; set;}
        public TelephoneContact(long zoneCode, string contactName)
        {
            ContactName = contactName;
            ZoneCode = zoneCode;
        }
        public override string ToString()
        {
            return string.Format("Contact - Number: {0}, name - {1}",  ZoneCode, ContactName);
        }
    }
}
