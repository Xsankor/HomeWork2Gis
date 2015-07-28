using Contacts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;

namespace Unittest
{
    [TestClass()]
    public class ContactTest
    {
        private TestContext testContextInstance;
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

        /*
        internal virtual Contact CreateContact()
        {
            // TODO: Instantiate an appropriate concrete class.
            //Contact target = null;
            Contact target = null;
            return target;
        }*/

        /// <summary>
        ///A test for ContactName
        ///</summary>
        [TestMethod()]
        public void ContactNameTest()
        {
            ContactExample target = new ContactExample();
            string expected = "Test Name";
            string actual;
            target.ContactName = expected;
            actual = target.ContactName;
            Assert.AreEqual(expected, actual, "Поле ContactName класса Contact не изменилось");
        }

        /// <summary>
        ///A test for ToXml
        ///</summary>
        [TestMethod()]
        public void ToXmlTest()
        {   
            ContactExample target = new ContactExample();
            string name = "Test Name";
            string expected = string.Format("<Contacts Name=\"{0}\" />", name);
            target.ContactName = name;
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
            ContactExample target = new ContactExample();
            string name = "Test Name";
            target.ContactName = name;
            string expected = string.Format("Contact Name: {0}", name);
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual, "Созданная строка отличается от ожидаемой");
        }

        /// <summary>
        ///A test for CompareTo
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            ContactExample target = new ContactExample();
            string name = "Test Name";
            target.ContactName = name;
            ContactExample ct = null;
            int actual;
            actual = target.CompareTo(ct);
            Assert.IsTrue(actual == 1, "Результат сравнения некорректен");
        }
    }

    class ContactExample : Contact
    {
        public ContactExample()
        {
        }
    }
}
