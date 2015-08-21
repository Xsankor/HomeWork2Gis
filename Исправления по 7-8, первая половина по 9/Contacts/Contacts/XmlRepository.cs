using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Contacts
{
    public class XmlRepository 
    {
        public void SaveToXML(Card card)
        {
            string path = "C:\\Temp\\card.xml";
            card.SerializedObject = new XmlSerializer(typeof(Card));
            var xml = card.SerializedObject;
            using (Stream s = File.Create(path))
            xml.Serialize(s, card);
        }

        public void LoadTOXML()
        {
            string path = "C:\\Temp\\card.xml";
            var xml = new XmlSerializer(typeof(Card));
            FileStream file = new FileStream(path, FileMode.Open);
            Card card = (Card) xml.Deserialize(file);

        }
    }
}
