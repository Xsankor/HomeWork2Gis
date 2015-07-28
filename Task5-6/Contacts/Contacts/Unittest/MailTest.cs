using Contacts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;

namespace Unittest
{
    [TestClass()]
    public class MailTest
    {
        private TestContext testContextInstance;
        string _mail;
        string contactName;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _mail = "test@mail.ru";
            contactName = "Иванов И.И.";
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        public void mailTest()
        {
            Mail target = new Mail(_mail, contactName); 
            string expected = string.Empty; 
            string actual;
            target.mail = expected;
            actual = target.mail;
            Assert.AreEqual(expected, actual, "c");
        }

        /// <summary>
        ///A test for ToXml
        ///</summary>
        [TestMethod()]
        public void ToXmlTest()
        {
            Mail target = new Mail(_mail, contactName); 
            string expected = string.Format("<Contacts>\r\n  <Mail>\r\n    <Name Value=\"{0}\" />\r\n    <mail Value=\"{1}\" />\r\n  </Mail>\r\n</Contacts>", contactName, _mail);
            XElement actual;
            actual = target.ToXml();
            Assert.AreEqual(expected, actual.ToString(), "Сформированное xml не соответствует ожидаемому");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Mail target = new Mail(_mail, contactName);
            string expected = string.Format("Contact - mailto: ({0}), name - {1}", _mail, contactName);
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual, "Созданная строка отличается от ожидаемой");
        }

        /// <summary>
        ///A test for CompareTo
        ///</summary>
        ///
        [TestMethod()]
        public void CompareToTest()
        {
            Mail target = new Mail(_mail, contactName); 
            Mail mailContact = null;
            int actual;
            actual = target.CompareTo(mailContact);
            Assert.IsTrue(actual == 1, "Результат сравнения некорректен");
        }

        /// <summary>
        ///A test for Mail Constructor
        ///</summary>
        [TestMethod()]
        public void MailConstructorTest()
        {
            Mail target = new Mail(_mail, contactName);
            Assert.AreEqual(_mail, target.mail, "Поле mail у созданного класса не совпалдет со значеним mail, переданном в параметрах");
            Assert.AreEqual(contactName, target.ContactName, "Поле contactName у созданного класса не совпалдет со значеним contactName, переданном в параметрах");
        }
    }
}
