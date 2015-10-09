using HttpRequestHelper;

using Newtonsoft.Json;

using NUnit.Framework;

namespace AutoQA1
{
    class Program
    {
        static void Main()
        {
        }

        [Test]
        public void ContactServise_AddContactTest()
        {
            // Узнаем количество контактов до добавления объекта
            var countBeforeAdd = System.Convert.ToInt32(GetContactCount());
            var expectedTestName = "JohnDoeTest1";
            var expectedTestPhone = "7777777";

            // Добавление контакта и валидация
            var request =
                new GetRequest(
                    "http://uk-autoqa01/wsc-test/ContactsService/service.asmx/AddContact?name=" + expectedTestName
                    + "&phone=" + expectedTestPhone);

            var answear = request.GetResponse().StatusCode;
            Assert.AreEqual("OK", answear.ToString(), "Сервис вернул {0}, не удалось добавить объект в ContactServise", answear);

            var countAfterAdd = System.Convert.ToInt32(GetContactCount());
            Assert.AreEqual(
                countBeforeAdd + 1,
                countAfterAdd,
                "Количество кантактов не совпадает, ожидалось - {0}, а в базе - {1}",
                countBeforeAdd + 1,
                countAfterAdd); 

            var query = "http://uk-autoqa01/wsc-test/ContactsService/service.asmx/GetContacts?count=" + countAfterAdd.ToString();
            var responseGetContacts = new GetRequest(query);
            var answearGetContacts = responseGetContacts.GetResponse().StringData();
            var testObjectContacts = Newtonsoft.Json.Linq.JObject.Parse(answearGetContacts);
            var testName = string.Empty;
            var testPhone = string.Empty;
            foreach (var testObjectContact in testObjectContacts["contacts"])
            {
                if (testObjectContact["Id"].ToString() == countAfterAdd.ToString())
                {
                    testName = testObjectContact["Name"].ToString();
                    testPhone = testObjectContact["Phone"].ToString();
                }
                
            }

            Assert.AreEqual(expectedTestName, testName, "Имя контакта не совпало с ожидаемым");
            Assert.AreEqual(expectedTestPhone, testPhone, "Номер контакта не совпал с ожидаемым");
        }

        private string GetContactCount()
        {
            var requestCount = new GetRequest("http://uk-autoqa01/wsc-test/ContactsService/service.asmx/GetCount");
            var answearCount = requestCount.GetResponse().StringData();
            var testObjectCount = Newtonsoft.Json.Linq.JObject.Parse(answearCount);
            var countContact = JsonConvert.DeserializeObject(testObjectCount["count"].ToString());
            return countContact.ToString();
        }
    }
}
