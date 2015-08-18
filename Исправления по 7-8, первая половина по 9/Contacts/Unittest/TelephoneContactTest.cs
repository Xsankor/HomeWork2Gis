using Contacts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;

namespace Unittest
{
    /// <summary>
    ///This is a test class for TelephoneContactTest and is intended
    ///to contain all TelephoneContactTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TelephoneContactTest
    {
        long zoneCode;
        string contactName;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            zoneCode = 111;
            contactName = "Иванов И.И.";
        }

        /// <summary>
        ///A test for TelephoneContact Constructor
        ///</summary>
        [TestMethod()]
        public void TelephoneContactConstructorTest()
        {
            TelephoneContact target = new TelephoneContact(zoneCode, contactName);
            Assert.AreEqual(zoneCode, target.ZoneCode, "Поле ZoneCode у созданного класса не совпалдет со значеним ZoneCode, переданном в параметрах");
            Assert.AreEqual(contactName, target.ContactName, "Поле contactName у созданного класса не совпалдет со значеним contactName, переданном в параметрах");
        }

        /// <summary>
        ///A test for CompareTo
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            TelephoneContact target = new TelephoneContact(zoneCode, contactName); 
            TelephoneContact phoneContact = null; 
            int actual;
            actual = target.CompareTo(phoneContact);
            Assert.IsTrue(actual == 1, "Результат сравнения некорректен");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            TelephoneContact target = new TelephoneContact(zoneCode, contactName);
            string expected = string.Format("Contact - Number: {0}, name - {1}", zoneCode, contactName);
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual, "Созданная строка отличается от ожидаемой");
        }

        /// <summary>
        ///A test for ToXml
        ///</summary>
        [TestMethod()]
        public void ToXmlTest()
        {
            TelephoneContact target = new TelephoneContact(zoneCode, contactName);
            var expected = string.Format("<Contacts>\r\n  <PhoneContacts>\r\n    <Name Value=\"{0}\" />\r\n    <ZoneCode Value=\"{1}\" />\r\n  </PhoneContacts>\r\n</Contacts>", contactName, zoneCode); 
            XElement actual;
            actual = target.ToXml();
            Assert.AreEqual(expected, actual.ToString(), "Сформированное xml не соответствует ожидаемому"); ;
        }

        /// <summary>
        ///A test for ZoneCode
        ///</summary>
        [TestMethod()]
        public void ZoneCodeTest()
        {
            TelephoneContact target = new TelephoneContact(zoneCode, contactName); 
            long expected = 0;
            long actual;
            target.ZoneCode = expected;
            actual = target.ZoneCode;
            Assert.AreEqual(expected, actual, "Поле ZoneCode класса TelephoneContact не изменилось");
        }
    }
}
