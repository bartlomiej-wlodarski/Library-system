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
			Library.AddClient(new Data.Client(4, "Piotr", "Wawrzynkiewicz", 22));

			Assert.AreEqual(4, Library.GetClient(4).Id);
			Assert.AreEqual("Piotr", Library.GetClient(4).Name);
			Assert.AreEqual("Wawrzynkiewicz", Library.GetClient(4).Surname);
			Assert.AreEqual(22, Library.GetClient(4).Age);
		}

	}
}
