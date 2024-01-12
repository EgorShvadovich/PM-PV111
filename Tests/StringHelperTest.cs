using App;

namespace Tests
{
    //структура модульних тестів відповідає структурі самого проєкту
    //кожному модулю(класу) пронрами є модуль (клас) тестів
    [TestClass]
    public class StringHelperTest
    {
        //кожному методу - тестовий метод(або декілька)
        [TestMethod]
        public void EllipsisTest()
        {
            StringHelper stringHelper = new();
            Assert.IsNotNull(stringHelper,"New StringHelper should be Non-Null");
            Assert.AreEqual("Hello...", stringHelper.Ellipsis("Hello,World!", 5), "'Hello,World!' -> 'Hello...'");
            Assert.AreEqual("Тести слід роби...", stringHelper.Ellipsis("Тести слід робити таким чином", 15));
        }
    }
}