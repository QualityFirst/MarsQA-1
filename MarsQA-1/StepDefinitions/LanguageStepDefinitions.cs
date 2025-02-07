using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1
{
    [Binding]
    public class LanguageStepDefinitions : Driver
    {
        public string lastLanguageRecord;

        [When(@"User adds a new language and level to the profile section")]
        public void WhenUserAddsANewLanguageAndLevelToTheProfileSection()
        {
            IWebElement addNewLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewLanguageButton.Click();

            IWebElement addLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            addLanguageTextBox.SendKeys("Spanish");

            IWebElement languageLevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            languageLevelDropDown.Click();
            Thread.Sleep(3000);

            IWebElement selectLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[4]"));
            selectLanguageLevel.Click();

            IWebElement addNewLanguageAndLevelToProfile = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addNewLanguageAndLevelToProfile.Click();
        }

        [Then(@"The language is successfully added to the profile")]
        public void ThenTheLanguageIsSuccessfullyAddedToTheProfile()
        {
            Language language = new Language();
            string newLanguage = language.GetLanguage(driver);
            string getTheLastLevelValue = language.GetLanguageLevel(driver);
            Assert.That(newLanguage == "Spanish", "Actual language and expected language values do not match.");
            Assert.That(getTheLastLevelValue == "Fluent", "Actual level and expected level values do not match.");
        }

        [When(@"User edits an existing language and level on the profile section")]
        public void WhenUserEditsAnExistingLanguageAndLevelOnTheProfileSection()
        {
            IWebElement getTheLastRowEditIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr[last()]/td[3]/span[1]"));
            getTheLastRowEditIcon.Click();

            IWebElement languageText = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            languageText.Clear();
            languageText.SendKeys("French");

            IWebElement languageLevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            languageLevelDropDown.Click();
            Thread.Sleep(3000);

            IWebElement selectLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[3]"));
            selectLanguageLevel.Click();

            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr[last()]/td/div/span/input[1]"));
            updateButton.Click();
        }

        [Then(@"The language is successfully updated on the profile")]
        public void ThenTheLanguageIsSuccessfullyUpdatedOnTheProfile()
        {
            IWebElement editedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement editedLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            Thread.Sleep(2000);

            Assert.That(editedLanguage.Text == "French", "Actual language and expected language values do not match.");
            Assert.That(editedLevel.Text == "Conversational", "Actual level and expected level values do not match.");
        }

        [When(@"User deletes an existing language and level on the profile section")]
        public void WhenUserDeletesAnExistingLanguageAndLevelOnTheProfileSection()
        {
            IWebElement getTheLastLanguageName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr[last()]/td[1]"));
            lastLanguageRecord = getTheLastLanguageName.Text;
            IWebElement getTheLastRowDeleteIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr[last()]/td[3]/span[2]"));
            getTheLastRowDeleteIcon.Click();
        }

        [Then(@"The language is successfully deleted from the profile")]
        public void ThenTheLanguageIsSuccessfullyDeletedFromTheProfile()
        {
            Language language = new Language();
            string lastLanguage = language.GetLanguage(driver);

            Assert.That(lastLanguageRecord == lastLanguage, "The language has not been deleted successfully");
        }
    }
}
