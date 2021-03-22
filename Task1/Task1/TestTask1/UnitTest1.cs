using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace TestTask1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 testClass = new Class1();
            float testValue;
            testValue = testClass.calc(15, 17);
            Assert.AreEqual(32, testValue);
        }
    }
}
