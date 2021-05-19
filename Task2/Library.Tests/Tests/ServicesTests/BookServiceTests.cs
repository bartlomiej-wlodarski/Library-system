using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Logic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Library.LogicTests
{
    [TestClass]
    public class BooksServiceTests
    {
        private readonly BookService service = new BookService(new LibraryDataContext());
        readonly DateTime date_1 = new DateTime(1943, 4, 6);
        readonly DateTime date_2 = new DateTime(1997, 6, 26);
        readonly DateTime date_3 = new DateTime(2018, 10, 20);

        /*public BooksServiceTests()
        {
            List<Books> Bookss = new List<Books>
            {
                new Books(),
                new Books(1, "Maly Ksiaze", "Saint-Exupery", 120, BooksGenre.Childrens, date_1),
                new Books(2, "Harry Potter and the Philosopher's Stone", "J. K. Rowling", 667, BooksGenre.Fantasy, date_2),
                new Books(3, "Chrobot", "Tomasz Michniewicz", 320, BooksGenre.Personal, date_3)
            };
            service.AddBooks(Bookss);
        }*/

        [TestMethod]
        public void DbRepositoryAddBooksTest()
        {
            Assert.AreEqual(0, service.GetBooksNumber());

            service.AddBook(4, "Nie ma", "Mariusz Szczygiel", 332, 4, new DateTime(2018, 6, 12));
            service.AddBook(5, "Krolestwo", "Szczepan Twardoch", 380, 2, new DateTime(2017, 11, 20));
            service.AddBook(6, "Krol", "Szczepan Twardoch", 350, 7, new DateTime(2016, 12, 24));

            Assert.AreEqual(3, service.GetBooksNumber());
        }

        /*[TestMethod]
        public void DbRepositoryAddBooksListTest()
        {
            List<Books> listOfBookss = new List<Books>
            {
                new Books(4, "Nie ma", "Mariusz Szczygiel", 332, BooksGenre.Personal, new DateTime(2018, 6, 12)),
                new Books(5, "Krolestwo", "Szczepan Twardoch", 380, BooksGenre.Horror, new DateTime(2017, 11, 20)),
                new Books(6, "Krol", "Szczepan Twardoch", 350, BooksGenre.Horror, new DateTime(2016, 12, 24))
            };
            service.AddBooks(listOfBookss);

            Assert.AreEqual(6, service.GetBookssNumber());
        }*/

        [TestMethod]
        public void DbRepositoryRemoveBooksTest()
        {
            service.AddBook(4, "Nie ma", "Mariusz Szczygiel", 332, 4, new DateTime(2018, 6, 12));

            Assert.AreEqual(1, service.GetBooksNumber());

            service.RemoveBook(1);

            Assert.AreEqual(0, service.GetBooksNumber());
        }

        [TestMethod]
        public void DbRepositoryGetBooksCatalogTest()
        {
            service.AddBook(1, "Maly Ksiaze", "Saint-Exupery", 120, 3, date_1);

            Assert.AreEqual(1, service.GetBook(1).Id);
            Assert.AreEqual("Maly Ksiaze", service.GetBook(1).Title);
            Assert.AreEqual("Saint-Exupery", service.GetBook(1).Author);
            Assert.AreEqual(120, service.GetBook(1).Pages);
            Assert.AreEqual(3, service.GetBook(1).Genre);
            Assert.AreEqual(date_1, service.GetBook(1).Date_of_publication);
        }

        [TestMethod]
        public void DbRepositoryEditBooksTest()
        {
            service.EditBook(1, "Duzy Krol", "Szczepan Twardoch", 350, 4, new DateTime(2016, 12, 24));

            Assert.AreEqual(1, service.GetBook(1).Id);
            Assert.AreEqual("Duzy Krol", service.GetBook(1).Title);
            Assert.AreEqual("Szczepan Twardoch", service.GetBook(1).Author);
            Assert.AreEqual(350, service.GetBook(1).Pages);
            Assert.AreEqual(4, service.GetBook(1).Genre);
            Assert.AreEqual(new DateTime(2016, 12, 24), service.GetBook(1).Date_of_publication);
        }

        [TestMethod]
        public void DbRepositoryCatalogTest()
        {
            service.AddBook(1, "Maly Ksiaze", "Saint-Exupery", 120, 3, date_1);

            IEnumerable<Books> catalog = service.GetBookCatalog();
            Assert.IsTrue(catalog.Contains(service.GetBook(1)));
        }

        [TestMethod]
        public void CheckAvaiabilityTest()
        {
            service.AddBook(1, "Maly Ksiaze", "Saint-Exupery", 120, 3, date_1);

            Assert.IsTrue(service.CheckAvaiability(1));
          
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "check damage of non-existent Books")]
        public void CheckIfDamagedTest()
        {
            service.CheckIfDamaged(1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "report damage of null Clients for null Books")]
        public void ReportDamagedTest()
        {
            service.ReportDamaged(1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "report rapaired of null Clients for null Books")]
        public void ReportRepairedTest()
        {
            service.ReportRepaired(2);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "rent null Books")]
        public void RentBooksTest()
        {
            service.RentEvents(3);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "return null Books")]
        public void ReturntBooksTest()
        {
            service.ReturnEvents(6);
        }
    }
}