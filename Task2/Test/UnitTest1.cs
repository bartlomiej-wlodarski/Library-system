using Library.Logic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BookService service = new BookService();
            service.AddBook(new Library.Data.Book());
        }
    }
}
