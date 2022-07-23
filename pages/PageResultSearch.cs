using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.ObjectModel;

namespace TestProject1.pages
{
    internal class PageResultSearch
    {
        public PageResultSearch(IWebDriver Driver)
        {
            PageFactory.InitElements(Driver, this);
            InitialLinks();
        }

        [FindsBy(How = How.XPath, Using = ".//ul[@class='search__results']")]
        private IWebElement Results { get; set; }

        public Collection<IWebElement> Links = new();

        private void InitialLinks()
        {
            foreach (IWebElement buf in Results.FindElements(By.XPath(".//a[@class='product__title-link']")))
                Links.Add(buf);
        }
    }
}
