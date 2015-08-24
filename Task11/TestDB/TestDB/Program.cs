using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Xml;

namespace TestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new TestDBEntities())
            {
                foreach (var card in dbContext.Cards)
                {
                    Console.WriteLine("Card_Id: {0}, Name {1}", card.Id, card.Name);
                }
                Console.ReadKey();

                // Загрузка из xml
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Cards));
                System.IO.StreamReader file = new System.IO.StreamReader(
                    @"c:\temp\SerializationOverview.xml");
                Cards loadCard = (Cards)reader.Deserialize(file);
                var idExist = dbContext.Cards.Any(c => c.Id == loadCard.Id);

                if (!idExist)
                {
                    // Добавляем карточку в базу, если такого id нет
                    dbContext.Cards.AddObject(loadCard);
                    dbContext.SaveChanges();
                }
                else
                {
                    // Обновляем поля у существующей карточки
                    Cards modifiedCard = dbContext.Cards.First(c => c.Id == loadCard.Id);
                    modifiedCard.Name = loadCard.Name;
                    modifiedCard.StatusTypeId = loadCard.StatusTypeId;
                    modifiedCard.SynCode = loadCard.SynCode;
                    modifiedCard.BranchId = loadCard.BranchId;
                    // Проверяем, если нет контакта в объекте, сформированном из xml, то удаляем контакт
                    foreach (var contact in modifiedCard.Contacts)
                    {
                        var deletedResult = loadCard.Contacts.Where(ct => ct.Id == contact.Id).Any();
                        if (!deletedResult)
                        {
                            dbContext.Contacts.DeleteObject(contact);
                            dbContext.SaveChanges();
                        }
                    }

                    foreach (var contact in loadCard.Contacts)
                    {
                        var newContactIdList = loadCard.Contacts.ToList();

                        var currentContact = dbContext.Contacts.First(ct => ct.Id == contact.Id);
                        if (currentContact != null)
                        {
                            // Обновляем контакты
                            currentContact.Value = contact.Value;
                            currentContact.ContactTypeId = contact.ContactTypeId;
                            currentContact.CardId = contact.CardId;
                        }

                        else
                        {
                            // Добавляем новый контакт
                            modifiedCard.Contacts.Add( new Contacts {ContactTypeId = currentContact.ContactTypeId, Value = currentContact.Value});
 
                        }

                    }
                        dbContext.SaveChanges();
 
                }
                
            }
        }
    }
}
