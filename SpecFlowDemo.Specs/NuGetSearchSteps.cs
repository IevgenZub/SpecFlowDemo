using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SpecFlowDemo.Specs
{
    [Binding]
    public class NuGetSearchSteps
    {
        const string NuGetHomeUrl = "http://www.nuget.org/";
        const string NuGetHomeTitle = "NuGet Gallery | Home";
        const string ExpectedSearchResultsTitle = "NuGet Gallery | Packages matching selenium";

        [Given(@"I am on the NuGet home page")]
        public void GivenIAmOnTheNuGetHomePage()
        {
            WebBrowser.Current.Navigate().GoToUrl(NuGetHomeUrl);
            //Check that the Title is what we are expecting
            Assert.AreEqual(NuGetHomeTitle, WebBrowser.Current.Title);
        }

        [When(@"I search for text (.*)")]
        public void WhenISearchForTextSelenium(string keyword)
        {
            // Find the text input element by its name
            IWebElement query = WebBrowser.Current.FindElement(By.Name("q"));
            // Input the search text
            query.SendKeys(keyword);
            // Now submit the form
            query.Submit();

            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 5 seconds
            var wait = new WebDriverWait(WebBrowser.Current, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.Id("searchResults")));
        }

        [Then(@"I should see the search results")]
        public void ThenIShouldSeeTheSearchResults()
        {
            Assert.AreEqual(ExpectedSearchResultsTitle, WebBrowser.Current.Title);
        }
    }
}
