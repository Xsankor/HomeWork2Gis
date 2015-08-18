using Contacts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;

namespace Unittest
{   
    /// <summary>
    ///This is a test class for CardTest and is intended
    ///to contain all CardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CardTest
    {
        long synCode = 111;
        string name = "Test Name"; 

        /// <summary>
        ///A test for Card Constructor
        ///</summary>
        [TestMethod()]
        public void CardConstructorTest()
        {
            Card target = new Card(synCode, name);
            Assert.IsNotNull(target, "Класс Card является Null");
        }

        /// <summary>
        ///A test for Card Constructor - Проверка того, что при отрицательном SynCod-е выйдет сообщение об ошибке
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Сервис не вернул сообщение об ошибке при создании карточки с отрицательным SynCod-ом")]
        public void CardConstructorTest_CheckSynCodeIsNegativeException()
        {
            Card target = new Card(-1, name);
        }

        /// <summary>
        ///A test for Card Constructor - Проверка того, что при нулевом SynCod-е выйдет сообщение об ошибке
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Сервис не вернул сообщение об ошибке при создании карточки с нулевым SynCod-ом")]
        public void CardConstructorTest_CheckSynCodeIsZeroException()
        {
            Card target = new Card(0, name);
        }

        /// <summary>
        ///A test for Card Constructor - Проверка того, что при пустом поле Name выйдет сообщение об ошибке
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Сервис не вернул сообщение об ошибке при создании карточки с пустым полем Name")]
        public void CardConstructorTest_CheckNameEmptyException()
        {
            Card target = new Card(synCode, string.Empty);
        }

        /// <summary>
        ///A test for Card Constructor
        ///</summary>
        [TestMethod()]
        public void CardConstructorTest1()
        {
            Card target = new Card();
            Assert.IsNotNull(target, "Класс Card является Null");
        }

        /// <summary>
        ///A test for AddMailContactToCard
        ///</summary>
        [TestMethod()]
        public void AddMailContactToCardTest()
        {
            Card target = new Card();
            int expectedCount = target.ContactList.Count + 1;
            Mail mailContact = new Mail ("test@mail.ru", "Test Contact"); 
            Card actual;
            actual = target.AddMailContactToCard(mailContact, target);
            int actualCount = actual.ContactList.Count;
            Assert.AreEqual(expectedCount, actualCount, "Mail контакт не добавлен к карточке");
        }

        /// <summary>
        ///A test for AddTelephoneContactToCard
        ///</summary>
        [TestMethod()]
        public void AddTelephoneContactToCardTest()
        {
            Card target = new Card();
            int expectedCount = target.ContactList.Count + 1;
            TelephoneContact telephoneContact = new TelephoneContact(111, "Test Contact");
            Card actual;
            actual = target.AddTelephoneContactToCard(telephoneContact, target);
            int actualCount = actual.ContactList.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        ///A test for ChangeCardName
        ///</summary>
        [TestMethod()]
        public void ChangeCardNameTest()
        {
            Card target = new Card(); 
            string newName = "New Name";
            target.ChangeCardName(newName);
            var actual = target.GetNameByCard(target);
            Assert.AreEqual(newName, actual, "Поле Name класса Card не изменилось");
        }

        /// <summary>
        ///A test for ChangeCardName -  Проверка того, что при пустом поле Name выйдет сообщение об ошибке
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Сервис не вернул сообщение об ошибке при обновлении карточки пустым полем Name")]
        public void ChangeCardNameTest_CheckNameEmptyException()
        {
            Card target = new Card();
            string newName = string.Empty;
            target.ChangeCardName(newName);
        }

        /// <summary>
        ///A test for ChangeCardSynCode
        ///</summary>
        [TestMethod()]
        public void ChangeCardSynCodeTest()
        {
            Card target = new Card(); 
            long newSynCode = 100; 
            target.ChangeCardSynCode(newSynCode);
            var actual = target.GetSynCodeByCard(target);
            Assert.AreEqual(newSynCode, actual, "Поле SynCode класса Card не изменилось");
        }

        /// <summary>
        ///A test for ChangeCardSynCode - Проверка того, что при отрицательном SynCod-е выйдет сообщение об ошибке
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Сервис не вернул сообщение об ошибке при обновлении у карточки поля SynCode отрицательным значением")]
        public void ChangeCardSynCodeTest_CheckSynCodeIsNegativeException()
        {
            Card target = new Card();
            long newSynCode = -100;
            target.ChangeCardSynCode(newSynCode);
        }

        /// <summary>
        ///A test for ChangeCardSynCode - Проверка того, что при нулевом SynCod-е выйдет сообщение об ошибке
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Сервис не вернул сообщение об ошибке при обновлении у карточки поля SynCode нулевым значением")]
        public void ChangeCardSynCodeTest_CheckSynCodeIsZeroException()
        {
            Card target = new Card();
            long newSynCode = 0;
            target.ChangeCardSynCode(newSynCode);
        }

        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void CloneTest()
        {
            Card target = new Card(); 
            Mail mailContact = new Mail("test@mail.ru", "Test Contact");
            target.AddMailContactToCard(mailContact, target);
            var actual = target.Clone();

            Assert.ReferenceEquals((Object)target, actual);
        }

        /// <summary>
        ///A test for CompareTo
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            Card target = new Card(); 
            Card card = null;
            int actual;
            actual = target.CompareTo(card);
            Assert.IsTrue(actual == 1, "Результат сравнения некорректен");
        }

        /// <summary>
        ///A test for GenerateCardId
        ///</summary>
        [TestMethod()]
        public void GenerateCardIdTest()
        {
            Card target = new Card(); 
            long number = 111; 
            long expected = number + 1;
            long actual = target.GenerateCardId(number);
            Assert.AreEqual(expected, actual, "Сгенерированное значение id = {0} отличается от ожидаемого id = {1}", expected, actual);
        }

        /// <summary>
        ///A test for GetIdByCard
        ///</summary>
        [TestMethod()]
        public void GetIdByCardTest()
        {
            Card target = new Card();
            long expected = 0; 
            long actual;
            actual = target.GetIdByCard(target);
            Assert.AreEqual(expected, actual, "Полученное id = {0} отличается от ожидаемого id = {1}", actual, expected);
        }

        /// <summary>
        ///A test for GetNameByCard
        ///</summary>
        [TestMethod()]
        public void GetNameByCardTest()
        {
            string _name = "Test Name";
            long SynCode = 495;
            Card target = new Card(SynCode, _name);
            string actual;
            actual = target.GetNameByCard(target);
            Assert.AreEqual(_name, actual, "Поле Name карточки отличается от ожидаемого");
        }

        /// <summary>
        ///A test for GetProjectName
        ///</summary>
        [TestMethod()]
        public void GetProjectNameTest()
        {
            string _name = "Test Name";
            long SynCode = 495;
            Card target = new Card(SynCode, _name);
            string expected = _name + SynCode.ToString();
            string actual;
            actual = target.GetProjectName();
            Assert.AreEqual(expected, actual, "Название проекта не отличается от ожидаемого");
        }

        /// <summary>
        ///A test for GetSynCodeByCard
        ///</summary>
        [TestMethod()]
        public void GetSynCodeByCardTest()
        {
            string _name = "Test Name";
            long SynCode = 495;
            Card target = new Card(SynCode, _name);
            long actual;
            actual = target.GetSynCodeByCard(target);
            Assert.AreEqual(SynCode, actual, "Поле SynCode карточки отличается от ожидаемого");
        }

        /// <summary>
        ///A test for ToXml
        ///</summary>
        [TestMethod()]
        public void ToXmlTest()
        {
            string _name = "Test Name";
            long SynCode = 495;
            Card target = new Card(SynCode, _name);
            string expected = string.Format("<Card>\r\n  <Id Value=\"0\" />\r\n  <SynCode Value=\"{0}\" />\r\n  <Name Value=\"{1}\" />\r\n  <CardStatus Status=\"{2}\" />\r\n</Card>", SynCode, _name, target.cardStatus);
            XElement actual =  target.ToXml();
            actual = target.ToXml();
            string s = actual.ToString();
            Assert.AreEqual(expected, actual.ToString(), "Сформированное xml не соответствует ожидаемому");
        }
    }
}
