using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AIS_Shyam_Test
{
    class HomePage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='tab2']/a")]
        IWebElement Lnk_LMS;

        [FindsBy(How = How.XPath, Using = "//*[@id='tab2']/ul/li[1]/a/span")]
        IWebElement Lnk_MyLeaves;

        WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
            wait = new WebDriverWait(driver, (TimeSpan.FromMilliseconds(5000)));
        }

        public void ClickOnLMS()
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='tab2']/a")));
            Lnk_LMS.Click();
        }

        public void ClickOnMyLeaves()
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='tab2']/ul/li[1]/a/span")));
            Lnk_MyLeaves.Click();
        }        
        public MyLeaves GotoLeavePage() //Example date format 01/01/2021 , 03/01/2021 dd/mm/yyyy
        {
            ClickOnLMS();
            ClickOnMyLeaves();

            return new MyLeaves(driver);
        }
    }
}
