using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
	[TestClass]
	public class LogicTest
	{
		private Logic.ILibraryLogic Library;
		private Data.IDataService repository;

		DateTime date_1 = new DateTime(1943, 4, 6);
		DateTime date_2 = new DateTime(1997, 6, 26);
		DateTime date_3 = new DateTime(2018, 10, 20);

		[TestInitialize]
		public void Initialize()
		{

			Data.DataContext context = new Data.DataContext();
			repository = new TDataRepository(context);
			Library = new Logic.LibraryLogic(repository);
		}

		[TestMethod]
		public void LibraryLogicGetClientTest()
		{
			Library.AddClient(new Data.Client(1, "Piotr", "Wawrzynkiewicz", 22));

			Assert.AreEqual(1, Library.GetClient(1).Id);
			Assert.AreEqual("Piotr", Library.GetClient(1).Name);
			Assert.AreEqual("Wawrzynkiewicz", Library.GetClient(1).Surname);
			Assert.AreEqual(22, Library.GetClient(1).Age);
		}

		[TestMethod]
		public void LibraryLogicAddClientTest()
		{
			Assert.AreEqual(0, Library.GetClientsNumber());

			Library.AddClient(new Data.Client(1, "Mateusz", "Owczarek", 22));
			Library.AddClient(new Data.Client(2, "Maciej", "Kopa", 16));
			Library.AddClient(new Data.Client(3, "Monika", "Roksa", 23));

			Assert.AreEqual(3, Library.GetClientsNumber());
		}

		[TestMethod]
		public void LibraryLogicRemoveClientTest()
		{
			Library.AddClient(new Data.Client(1, "Mateusz", "Owczarek", 22));
			Library.AddClient(new Data.Client(2, "Maciej", "Kopa", 16));
			Library.AddClient(new Data.Client(3, "Monika", "Roksa", 23));

			Assert.AreEqual(3, Library.GetClientsNumber());

			Library.RemoveClient(1);

			Assert.AreEqual(2, Library.GetClientsNumber());
		}

		[TestMethod]
		public void LibraryLogicyGetClientTest()
		{
			Library.AddClient(new Data.Client(4, "Marek", "Mostowiak", 45));

			Assert.AreEqual(4, Library.GetClient(4).Id);
			Assert.AreEqual("Marek", Library.GetClient(4).Name);
			Assert.AreEqual("Mostowiak", Library.GetClient(4).Surname);
			Assert.AreEqual(45, Library.GetClient(4).Age);

		}

		[TestMethod]
		public void LibraryLogicGetClientCatalogTest()
		{
			Library.AddClient(new Data.Client(1, "Bartlomiej", "Wlodarski", 20));
			List<Data.Client> catalog = Library.GetClientCatalog();

			Assert.AreEqual(1, Library.GetClient(1).Id);
			Assert.AreEqual("Bartlomiej", Library.GetClient(1).Name);
			Assert.AreEqual("Wlodarski", Library.GetClient(1).Surname);
			Assert.AreEqual(20, Library.GetClient(1).Age);

		}

		[TestMethod]
		public void LibraryLogicEditClientTest()
		{
			Library.AddClient(new Data.Client(1, "Bartlomiej", "Wlodarski", 20));
			Library.EditClient(new Data.Client(1, "Bartlomiej", "Wlodarczyk", 21));

			Assert.AreEqual(1, Library.GetClient(1).Id);
			Assert.AreEqual("Bartlomiej", Library.GetClient(1).Name);
			Assert.AreEqual("Wlodarczyk", Library.GetClient(1).Surname);
			Assert.AreEqual(21, Library.GetClient(1).Age);
		}

		public void LibraryLogicAddEventTest()
		{
			Assert.AreEqual(0, Library.GetEventsNumber());

			Library.AddEvent(new Data.RentEvent(4, new Data.Client(4, "Monika", "Roksa", 23), new DateTime(1943, 4, 6), new Data.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(1943, 4, 6))));
			Library.AddEvent(new Data.RentEvent(5, new Data.Client(5, "Anna", "Przystanska", 34), new DateTime(2018, 10, 20), new Data.Book(5, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(1943, 4, 6))));

			Assert.AreEqual(2, Library.GetEventsNumber());
		}

		[TestMethod]
		public void LibraryLogicRemoveEventTest()
		{
			Library.AddEvent(new Data.RentEvent(1, new Data.Client(1, "Bartlomiej", "Wlodarski", 20), new DateTime(1943, 4, 6), new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(1943, 4, 6))));
			Library.AddEvent(new Data.RentEvent(2, new Data.Client(2, "Maciej", "Wlodarczyk", 21), new DateTime(1997, 6, 26), new Data.Book(2, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(1943, 4, 6))));

			Assert.AreEqual(2, Library.GetEventsNumber());

			Library.RemoveEvent(1);

			Assert.AreEqual(1, Library.GetEventsNumber());
		}

		[TestMethod]
		public void LibraryLogicGetEventCatalogTest()
		{
			Library.AddEvent(new Data.RentEvent(1, new Data.Client(1, "Bartlomiej", "Wlodarski", 20), new DateTime(1943, 4, 6), new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(1943, 4, 6))));
			List<Data.Event> catalog = Library.GetEventCatalog();

			Assert.AreEqual(1, Library.GetEvent(1).Id);
			Assert.AreEqual(1, Library.GetEvent(1).Client.Id);
			Assert.AreEqual("Bartlomiej", Library.GetEvent(1).Client.Name);
			Assert.AreEqual("Wlodarski", Library.GetEvent(1).Client.Surname);
			Assert.AreEqual(20, Library.GetEvent(1).Client.Age);
			Assert.AreEqual(new DateTime(1943, 4, 6), Library.GetEvent(1).Date);
		}
		
		[TestMethod]
		public void LibraryLogicEditEventTest()
		{
			repository.AddEvent(new Data.RentEvent(1, new Data.Client(1, "Bartlomiej", "Wlodarski", 20), new DateTime(1943, 4, 6), new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(1943, 4, 6))));
			repository.AddEvent(new Data.RentEvent(2, new Data.Client(2, "Maciej", "Wlodarczyk", 21), new DateTime(1997, 6, 26), new Data.Book(2, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(1943, 4, 6))));

			Library.EditEvent(new Data.RentEvent(1, new Data.Client(1, "Bartosz", "Wlodarczyk", 25), new DateTime(1997, 6, 26), new Data.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(1943, 4, 6))));

			Assert.AreEqual(1, Library.GetEvent(1).Id);
			Assert.AreEqual(1, Library.GetEvent(1).Client.Id);
			Assert.AreEqual("Bartosz", Library.GetEvent(1).Client.Name);
			Assert.AreEqual("Wlodarczyk", Library.GetEvent(1).Client.Surname);
			Assert.AreEqual(25, Library.GetEvent(1).Client.Age);
			Assert.AreEqual(new DateTime(1997, 6, 26), Library.GetEvent(1).Date);

			Library.EditEvent(new Data.RentEvent(2, new Data.Client(2, "Marco", "Murinho", 37), new DateTime(1943, 4, 6), new Data.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(1943, 4, 6))));

			Assert.AreEqual(2, Library.GetEvent(2).Id);
			Assert.AreEqual(2, Library.GetEvent(2).Client.Id);
			Assert.AreEqual("Marco", Library.GetEvent(2).Client.Name);
			Assert.AreEqual("Murinho", Library.GetEvent(2).Client.Surname);
			Assert.AreEqual(37, Library.GetEvent(2).Client.Age);
			Assert.AreEqual(new DateTime(1943, 4, 6), Library.GetEvent(2).Date);
		}
		[TestMethod]
		public void LibraryLogicAddBookTest()
		{
			Assert.AreEqual(0, Library.GetBooksNumber());

			Library.AddBook(new Data.Book(1, "Nie ma", "Mariusz Szczygiel", 332, Data.BookGenre.Personal, new DateTime(2018, 6, 12)));
			Library.AddBook(new Data.Book(2, "Krolestwo", "Szczepan Twardoch", 380, Data.BookGenre.Horror, new DateTime(2017, 11, 20)));
			Library.AddBook(new Data.Book(3, "Krol", "Szczepan Twardoch", 350, Data.BookGenre.Horror, new DateTime(2016, 12, 24)));

			Assert.AreEqual(3, Library.GetBooksNumber());
		}

		[TestMethod]
		public void LibraryLogicRemoveBookTest()
		{
			Library.AddBook(new Data.Book(1, "Nie ma", "Mariusz Szczygiel", 332, Data.BookGenre.Personal, new DateTime(2018, 6, 12)));
			Library.AddBook(new Data.Book(2, "Krolestwo", "Szczepan Twardoch", 380, Data.BookGenre.Horror, new DateTime(2017, 11, 20)));
			Library.AddBook(new Data.Book(3, "Krol", "Szczepan Twardoch", 350, Data.BookGenre.Horror, new DateTime(2016, 12, 24)));

			Assert.AreEqual(3, Library.GetBooksNumber());

			Library.RemoveBook(1);

			Assert.AreEqual(2, Library.GetBooksNumber());
		}

		[TestMethod]
		public void LibraryLogicGetBookTest()
		{
			Library.AddBook(new Data.Book(4, "Nie ma", "Mariusz Szczygiel", 332, Data.BookGenre.Personal, new DateTime(2018, 6, 12)));

			Assert.AreEqual(4, Library.GetBook(4).Id);
			Assert.AreEqual("Nie ma", Library.GetBook(4).Title);
			Assert.AreEqual("Mariusz Szczygiel", Library.GetBook(4).Author);
			Assert.AreEqual(332, Library.GetBook(4).Pages);
			Assert.AreEqual(Data.BookGenre.Personal, Library.GetBook(4).Genre);
			Assert.AreEqual(new DateTime(2018, 6, 12), Library.GetBook(4).Date_of_publication);
		}

		[TestMethod]
		public void LibraryLogicGetBookCatalogTest()
		{
			Library.AddBook(new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(1943, 4, 6)));
			Dictionary<int, Data.Book> catalog = Library.GetBookCatalog();

			Assert.AreEqual(1, Library.GetBook(1).Id);
			Assert.AreEqual("Maly Ksiaze", Library.GetBook(1).Title);
			Assert.AreEqual("Saint-Exupery", Library.GetBook(1).Author);
			Assert.AreEqual(120, repository.GetBook(1).Pages);
			Assert.AreEqual(Data.BookGenre.Childrens, Library.GetBook(1).Genre);
			Assert.AreEqual(new DateTime(1943, 4, 6), Library.GetBook(1).Date_of_publication);
		}

		[TestMethod]
		public void LibraryLogicEditBookTest()
		{
			Library.AddBook(new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(1943, 4, 6)));
			Library.EditBook(new Data.Book(1, "Duzy Krol", "Szczepan Twardoch", 350, Data.BookGenre.Horror, new DateTime(2016, 12, 24)));

			Assert.AreEqual(1, Library.GetBook(1).Id);
			Assert.AreEqual("Duzy Krol", Library.GetBook(1).Title);
			Assert.AreEqual("Szczepan Twardoch", Library.GetBook(1).Author);
			Assert.AreEqual(350, Library.GetBook(1).Pages);
			Assert.AreEqual(Data.BookGenre.Horror, Library.GetBook(1).Genre);
			Assert.AreEqual(new DateTime(2016, 12, 24), Library.GetBook(1).Date_of_publication);
		}

		[TestMethod]
		public void DataRepositoryCheckAvailabilityTest()
		{
			Library.AddBook(new Data.Book(4, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));

			Assert.IsTrue(Library.CheckAvaiability(new Data.Book(4, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
		}

		[TestMethod]
		public void DataRepositoryCheckIfDamagedTest()
		{
			Library.AddBook(new Data.Book(5, "Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));
			Library.ReportDamaged(new Data.Book(5, "Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1), new Data.Client(1, "Bartlomiej", "Wlodarski", 20), new DateTime(2018, 10, 20));

			Assert.IsTrue(Library.CheckIfDamaged(new Data.Book(5, "Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
		}

		[TestMethod]
		public void DataRepositoryCheckIfRepairdTest()
		{
			Library.AddBook(new Data.Book(5, "Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));
			Library.ReportDamaged(new Data.Book(5, "Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1), new Data.Client(1, "Bartlomiej", "Wlodarski", 20), new DateTime(2018, 10, 20));
			Assert.IsTrue(Library.CheckIfDamaged(new Data.Book(5, "Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
			Library.ReportRepaired(new Data.Book(5, "Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1), new Data.Client(1, "Bartlomiej", "Wlodarski", 20), new DateTime(2018, 10, 20));

			Assert.IsTrue(Library.CheckAvaiability(new Data.Book(5, "Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
		}

		[TestMethod]
		public void DataRepositoryRentEventTest()
		{
			Library.AddBook(new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));
			Library.AddClient(new Data.Client(6, "Bartosz", "Wlodarski", 20));
			Library.RentEvent(1, new Data.Client(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));

			Assert.IsFalse(Library.CheckAvaiability(new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
		}

		[TestMethod]
		public void DataRepositoryReturnEventTest()
		{
			Library.AddBook(new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));
			Library.AddClient(new Data.Client(6, "Bartosz", "Wlodarski", 20));
			Library.RentEvent(1, new Data.Client(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));

			Assert.IsFalse(Library.CheckAvaiability(new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));

			Library.ReturnEvent(1, new Data.Client(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));

			Assert.IsTrue(Library.CheckAvaiability(new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
		}

	}
}