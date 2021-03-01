using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using MSTestCookie.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSTestCookie.Pages
{
    class ExamplePage : Form
    {
        public ExamplePage() : base(By.XPath("//a[@href='https://www.iana.org/domains/example']"), "ExamplePage")
        {

        }

        public bool IsPageDisplayed()
        {
            return new ExamplePage().State.WaitForDisplayed();
        }

        public ExamplePage AddCookie(string key, string value)
        {
            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new Cookie(key, value));
            return this;
        }

        public bool CheckCookies()
        {
            return AqualityServices.Browser.Driver.Manage().Cookies.AllCookies.Contains(AqualityServices.Browser.Driver.Manage().Cookies.
                GetCookieNamed(JsonReader.GetParameter("cookie_name1"))) ||
            AqualityServices.Browser.Driver.Manage().Cookies.AllCookies.Contains(AqualityServices.Browser.Driver.Manage().Cookies.
            GetCookieNamed(JsonReader.GetParameter("cookie_name2"))) ||
            AqualityServices.Browser.Driver.Manage().Cookies.AllCookies.Contains(AqualityServices.Browser.Driver.Manage().Cookies.
            GetCookieNamed(JsonReader.GetParameter("cookie_name3")));
        }

        public ExamplePage DeleteCookie(string key)
        {
            AqualityServices.Browser.Driver.Manage().Cookies.DeleteCookie(AqualityServices.Browser.Driver.Manage().Cookies.GetCookieNamed(key));
            return this;
        }

        public bool CheckCookie(string key)
        {
            return AqualityServices.Browser.Driver.Manage().Cookies.AllCookies.Contains(AqualityServices.Browser.Driver.Manage().Cookies.
                GetCookieNamed(key));
        }

        public ExamplePage SetNewValueToCookie(string key, string value)
        {
            DeleteCookie(key);
            AddCookie(key, value);
            return this;
        }

        public string GetCookieValue(string key)
        {
            return AqualityServices.Browser.Driver.Manage().Cookies.GetCookieNamed(key).Value;
        }

        public ExamplePage DeleteAllCookies()
        {
            AqualityServices.Browser.Driver.Manage().Cookies.DeleteAllCookies();
            return this;
        }
    }
}
