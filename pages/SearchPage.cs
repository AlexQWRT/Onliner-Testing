using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.pages
{
    internal class SearchPage
    {
        public SearchPage(IWebDriver Driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//input[@class='fast-search__input']")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = ".//iframe[@class='modal-iframe']")]
        public IWebElement Frame { get; set; }
    }
}
