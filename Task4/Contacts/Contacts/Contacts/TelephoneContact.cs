using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    public class TelephoneContact : Contact
    {
        public long ZoneCode {get; set;}
        public TelephoneContact(long contactNumber, long zoneCode, string contactName)
        {
            ContactName = contactName;
            ContactNumber = contactNumber;
            ZoneCode = zoneCode;
        }
        public override string ToString()
        {
            return string.Format("Contact - Number: {0}-{1}, name - {2}",  ZoneCode, ContactNumber, ContactName);
        }
    }
}
