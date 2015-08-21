using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Contacts
{
    public interface IXmlSerializable
    {
        XmlSerializer SerializedObject {get; set;}
    }
}
