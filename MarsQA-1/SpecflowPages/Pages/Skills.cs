using OpenQA.Selenium;

namespace MarsQA_1.SpecflowPages.Pages
{
    public class Skills
    {
        public string GetSkill(IWebDriver driver)
        {
            IWebElement getTheLastSkillValue = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr[last()]/td[1]"));
            return getTheLastSkillValue.Text;
        }

        public string GetSkillLevel(IWebDriver driver)
        {
            IWebElement getTheSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));
            return getTheSkillLevel.Text;
        }
    }
}
