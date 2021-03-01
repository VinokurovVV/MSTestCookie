using Aquality.Selenium.Browsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestCookie.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSTestCookie.Tests
{
    public class BaseTest
    {
        private readonly Browser browser = AqualityServices.Browser;

        [TestInitialize]
        public void Setup()
        {
            browser.Maximize();
            browser.GoTo(JsonReader.GetParameter("url"));
            browser.WaitForPageToLoad();
        }


        [TestCleanup]
        public void TearDown()
        {
            if (browser != null)
            {
                browser.Quit();
            }
        }
    }
}
