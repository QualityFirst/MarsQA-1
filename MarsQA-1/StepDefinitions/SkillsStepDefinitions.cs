using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1
{
    [Binding]
    public class SkillsStepDefinitions : Driver
    {
        public string lastSkillRecord;

        [When(@"User adds a new skill and level to the profile section")]
        public void WhenUserAddsANewSkillAndLevelToTheProfileSection()
        {
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();

            IWebElement addNewSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewSkillButton.Click();

            IWebElement addSkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            addSkillTextBox.SendKeys("Coding");

            IWebElement skillLevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            skillLevelDropDown.Click();
            Thread.Sleep(3000);

            IWebElement selectSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]"));
            selectSkillLevel.Click();

            IWebElement addNewSkillAndLevelToProfile = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addNewSkillAndLevelToProfile.Click();
        }

        [Then(@"The skill is successfully added to the profile")]
        public void ThenTheSkillIsSuccessfullyAddedToTheProfile()
        {
            Skills skill = new Skills();
            string newSkill = skill.GetSkill(driver);
            string getTheLastLevelValue = skill.GetSkillLevel(driver);

            Assert.That(newSkill == "Coding", "Actual skill and expected skill values do not match.");
            Assert.That(getTheLastLevelValue == "Beginner", "Actual level and expected level values do not match.");
        }

        [When(@"User edits an existing skill and level on the profile section")]
        public void WhenUserEditsAnExistingSkillAndLevelOnTheProfileSection()
        {
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();

            IWebElement getTheLastRowEditIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr[last()]/td[3]/span[1]"));
            getTheLastRowEditIcon.Click();

            IWebElement skillText = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            skillText.Clear();
            skillText.SendKeys("Debugging");

            IWebElement skillLevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            skillLevelDropDown.Click();
            Thread.Sleep(3000);

            IWebElement selectSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[3]"));
            selectSkillLevel.Click();

            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
        }

        [Then(@"The skill is successfully updated on the profile")]
        public void ThenTheSkillIsSuccessfullyUpdatedOnTheProfile()
        {
            IWebElement editedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr[last()]/td[1]"));
            IWebElement editedLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));

            Thread.Sleep(2000);

            Assert.That(editedSkill.Text == "Debugging", "Actual skill and expected skill values do not match.");
            Assert.That(editedLevel.Text == "Intermediate", "Actual level and expected level values do not match.");
        }

        [When(@"User deletes an existing skill and level on the profile section")]
        public void WhenUserDeletesAnExistingSkillAndLevelOnTheProfileSection()
        {
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();

            Skills skill = new Skills();
            string lastSkill = skill.GetSkill(driver);
            string lastSkLevel = skill.GetSkillLevel(driver);

            lastSkillRecord = lastSkill;

            IWebElement getTheLastRowDeleteIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]"));
            getTheLastRowDeleteIcon.Click();
        }

        [Then(@"The skill is successfully deleted from the profile")]
        public void ThenTheSkillIsSuccessfullyDeletedFromTheProfile()
        {
            Skills skill = new Skills();
            string lastSkill = skill.GetSkill(driver);

            Assert.That(lastSkillRecord == lastSkill, "The skill has not been deleted successfully");
        }
    }
}
