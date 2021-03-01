using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestCookie.Pages;
using MSTestCookie.Tests;
using MSTestCookie.Utils;

namespace MSTestCookie
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ExamplePage examplePage = new ExamplePage();
            Assert.IsTrue(examplePage.IsPageDisplayed(),
                "ExamplePage is not opened.");

            examplePage.AddCookie(JsonReader.GetParameter("cookie_name1"), JsonReader.GetParameter("cookie_value1"))
                .AddCookie(JsonReader.GetParameter("cookie_name2"), JsonReader.GetParameter("cookie_value2"))
                .AddCookie(JsonReader.GetParameter("cookie_name3"), JsonReader.GetParameter("cookie_value3"));

            Assert.IsTrue(examplePage.CheckCookie(JsonReader.GetParameter("cookie_name1")),
            "Cookie1 is not delivired.");
            Assert.IsTrue(examplePage.CheckCookie(JsonReader.GetParameter("cookie_name2")),
            "Cookie2 is not delivired.");
            Assert.IsTrue(examplePage.CheckCookie(JsonReader.GetParameter("cookie_name3")),
            "Cookie3 is not delivired.");

            examplePage.DeleteCookie(JsonReader.GetParameter("cookie_name1"));
            Assert.IsFalse(examplePage.CheckCookie(JsonReader.GetParameter("cookie_name1")),
                "cookie_name1 is not deleted");

            examplePage.SetNewValueToCookie(JsonReader.GetParameter("cookie_name3"), JsonReader.GetParameter("cookie_value3.1"));
            Assert.AreEqual(JsonReader.GetParameter("cookie_value3.1"), examplePage.GetCookieValue(JsonReader.GetParameter("cookie_name3")),
                "Cookie don't get new value.");

            examplePage.DeleteAllCookies();
            Assert.IsTrue(!examplePage.CheckCookie(JsonReader.GetParameter("cookie_name1")),
            "Cookie1 is not deleted");
            Assert.IsTrue(!examplePage.CheckCookie(JsonReader.GetParameter("cookie_name2")),
            "Cookie2 is not deleted");
            Assert.IsTrue(!examplePage.CheckCookie(JsonReader.GetParameter("cookie_name3")),
            "Cookie3 is not deleted");
        }
    }
}
