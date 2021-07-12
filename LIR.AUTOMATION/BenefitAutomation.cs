using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace LIR.AUTOMATION
{
    public class BenefitAutomation
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("http://localhost:13902/");

                //open and configure setup
                driver.FindElement(By.Id("configureSetupBtn")).Click();
                DelayHelper.Pause(3000);

                driver.FindElement(By.Id("guaranteedIssue")).Clear();
                driver.FindElement(By.Id("guaranteedIssue")).SendKeys("50000");
                DelayHelper.Pause();

                driver.FindElement(By.Id("maxAgeLimit")).Clear();
                driver.FindElement(By.Id("maxAgeLimit")).SendKeys("50");
                DelayHelper.Pause();

                driver.FindElement(By.Id("minAgeLimit")).Clear();
                driver.FindElement(By.Id("minAgeLimit")).SendKeys("25");
                DelayHelper.Pause();

                driver.FindElement(By.Id("minimumRange")).Clear();
                driver.FindElement(By.Id("minimumRange")).SendKeys("1");
                DelayHelper.Pause();

                driver.FindElement(By.Id("maximumRange")).Clear();
                driver.FindElement(By.Id("maximumRange")).SendKeys("5");
                DelayHelper.Pause();

                driver.FindElement(By.Id("increments")).Clear();
                driver.FindElement(By.Id("increments")).SendKeys("1");
                DelayHelper.Pause();

                driver.FindElement(By.Id("submitSetupBtn")).Click();
                DelayHelper.Pause(3000);

                //view and close setup
                driver.FindElement(By.Id("configureSetupBtn")).Click();
                DelayHelper.Pause();

                driver.FindElement(By.Id("closeSetupBtn")).Click();
                DelayHelper.Pause(3000);

                //request computation
                driver.FindElement(By.Id("ConsumerName")).SendKeys("Charles");
                DelayHelper.Pause();

                driver.FindElement(By.Id("BasicSalary")).SendKeys("80000");
                DelayHelper.Pause();

                driver.FindElement(By.Id("Birthdate")).SendKeys("05/02/1996");
                DelayHelper.Pause();

                driver.FindElement(By.Id("submitComputationBtn")).Click();
                DelayHelper.Pause();

                driver.FindElement(By.Id("closeResultBtn")).Click();
                DelayHelper.Pause(3000);

                //reset fields
                driver.FindElement(By.Id("resetFormBtn")).Click();
                DelayHelper.Pause(3000);

                //view history
                driver.FindElement(By.Id("ConsumerName")).SendKeys("Charles");
                DelayHelper.Pause();

                driver.FindElement(By.Id("viewHistoryBtn")).Click();
                DelayHelper.Pause();

                driver.FindElement(By.Id("closeResultBtn")).Click();
                DelayHelper.Pause(3000);
            }
        }
    }
}
