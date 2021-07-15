using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SeleniumAutomation
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
                //open and configure setup
                driver.Navigate().GoToUrl("http://localhost:13902/Benefit/RetirementSetup");

                driver.FindElement(By.Id("GuaranteedIssue")).Clear();
                driver.FindElement(By.Id("GuaranteedIssue")).SendKeys("50000");
                DelayHelper.Pause();

                driver.FindElement(By.Id("MaxAgeLimit")).Clear();
                driver.FindElement(By.Id("MaxAgeLimit")).SendKeys("50");
                DelayHelper.Pause();

                driver.FindElement(By.Id("MinAgeLimit")).Clear();
                driver.FindElement(By.Id("MinAgeLimit")).SendKeys("25");
                DelayHelper.Pause();

                driver.FindElement(By.Id("MinimumRange")).Clear();
                driver.FindElement(By.Id("MinimumRange")).SendKeys("1");
                DelayHelper.Pause();

                driver.FindElement(By.Id("MaximumRange")).Clear();
                driver.FindElement(By.Id("MaximumRange")).SendKeys("5");
                DelayHelper.Pause();

                driver.FindElement(By.Id("Increments")).Clear();
                driver.FindElement(By.Id("Increments")).SendKeys("1");
                DelayHelper.Pause();

                driver.FindElement(By.Id("submitSetupBtn")).Click();
                DelayHelper.Pause(3000);

                //request computation
                driver.Navigate().GoToUrl("http://localhost:13902/");

                driver.FindElement(By.Id("ConsumerName")).Clear();
                driver.FindElement(By.Id("ConsumerName")).SendKeys("Charles");
                DelayHelper.Pause();

                driver.FindElement(By.Id("BasicSalary")).Clear();
                driver.FindElement(By.Id("BasicSalary")).SendKeys("80000");
                DelayHelper.Pause();

                driver.FindElement(By.Id("Birthdate")).Clear();
                driver.FindElement(By.Id("Birthdate")).SendKeys("05/02/1996");
                DelayHelper.Pause();

                driver.FindElement(By.Id("submitComputationBtn")).Click();
                DelayHelper.Pause(3000);

                //reset fields
                driver.FindElement(By.Id("resetFormBtn")).Click();
                DelayHelper.Pause(3000);

                //history
                driver.Navigate().GoToUrl("http://localhost:13902/Benefit/History");
                DelayHelper.Pause(3000);

                driver.FindElement(By.XPath("/html/body/div/main/div/div/div[2]/div/div[2]/div/table/tbody/tr[1]/td[1]/a")).Click();
                DelayHelper.Pause(3000);

                driver.FindElement(By.Id("ConsumerName")).Clear();
                driver.FindElement(By.Id("ConsumerName")).SendKeys("Charles Salamat");
                DelayHelper.Pause();

                driver.FindElement(By.Id("BasicSalary")).Clear();
                driver.FindElement(By.Id("BasicSalary")).SendKeys("80009");
                DelayHelper.Pause();

                driver.FindElement(By.Id("Birthdate")).Clear();
                driver.FindElement(By.Id("Birthdate")).SendKeys("05/01/1996");
                DelayHelper.Pause();

                driver.FindElement(By.Id("submitComputationBtn")).Click();
                DelayHelper.Pause(3000);
            }
        }
    }
}
