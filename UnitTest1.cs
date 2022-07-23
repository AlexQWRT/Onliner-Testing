using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TestProject1.pages;


namespace TestProject1
{
    public class Tests
    {
        private IWebDriver Driver;
        private string request;

        [SetUp]
        public void OpenBrowser()
        {
            Driver = new FirefoxDriver(@"drivers\");
            request = "Мышка"; //Введите сюда запрос для проверки
            Driver.Manage().Window.Maximize();
            Driver.Url = "https://www.onliner.by/";
        }

        [Test]
        public void Test1()
        {
            SearchPage pageSearch = new(Driver);
            pageSearch.SearchField.Click();
            pageSearch.SearchField.SendKeys(request);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(Driver => Driver.SwitchTo().Frame(pageSearch.Frame));
            long scrollHeight = 0;
            do
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                long newScrollHeight = (long)js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight); return document.body.scrollHeight;");

                if (newScrollHeight == scrollHeight)
                {
                    break;
                }
                else
                {
                    scrollHeight = newScrollHeight;
                    Thread.Sleep(1000);
                }
            } while (true);
            PageResultSearch pageResult = new(Driver);
            bool passed = false;
            for (int i = 0; i < pageResult.Links.Count; i++)
            {
                if (pageResult.Links[i].Text.Trim().ToLower().Contains(request.Trim().ToLower()))
                    passed = true;
            }
            if (passed)
                Assert.Pass("Results found.\n" + pageResult.Links.Count + " results checked.");
            else
                Assert.Fail("Results not found.");
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}