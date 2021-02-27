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
    class MyLeaves
    {
        IWebDriver driver;
        WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = ("/html/body/div[2]/aside[2]/section[2]/div[5]/div[2]/div[1]/div/div/div[1]/button[1]/span"))]
        IWebElement Btn_Leave;

        [FindsBy(How = How.XPath, Using = ("/html/body/div[2]/aside[2]/section[2]/div[5]/div[2]/div[1]/div/div/div[1]/button[2]/span"))]
        IWebElement Btn_WFH;

        public MyLeaves(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, (TimeSpan.FromMilliseconds(3000)));
        }

        public void ClickOnLeave()
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/div[2]/aside[2]/section[2]/div[5]/div[2]/div[1]/div/div/div[1]/button[1]/span")));
            Btn_Leave.Click();
        }
        public void ApplyLeave()
        {
            ClickOnLeave();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/aside[2]/section[2]/div[1]/div/div/div[2]/div/div/div/form/div[2]/input")));

           // string currentWindowHandle = driver.WindowHandles[0];
            //driver.SwitchTo().Window(currentWindowHandle).Title;

            driver.FindElement(By.XPath("/html/body/div[2]/aside[2]/section[2]/div[1]/div/div/div[2]/div/div/div/form/div[2]/input")).SendKeys("Test Leave");


            //AllDay Event
            IWebElement combohandle = driver.FindElement(By.XPath("//*[@id='AllDayEvent']"));
            SelectElement selectitem = new SelectElement(combohandle);
            selectitem.SelectByIndex(0);

            //from Date
            //driver.FindElement(By.XPath("//*[@id='datetimepickerStartDt']/span/span")).Click();
            //driver.FindElement(By.XPath("//*[@id='LeaveStartDate']")).Clear();
            //driver.FindElement(By.XPath("//*[@id='LeaveStartDate']")).SendKeys("02-23-2021 10:00 AM");

            //End Date
            //*[@id="datetimepickerEndDt"]/span/span
            //driver.FindElement(By.XPath("//*[@id='datetimepickerEndtDt']/span/span")).Click();
            //driver.FindElement(By.XPath("//*[@id='LeaveEndDate']")).Clear();
            //driver.FindElement(By.XPath("//*[@id='LeaveEndDate']")).SendKeys("02-24-2021 10:00 AM");

            //Absence Type
            combohandle = driver.FindElement(By.XPath("//*[@id='AbsenceTypeID']"));
            selectitem = new SelectElement(combohandle);
            selectitem.SelectByIndex(0);

            //Project Manager
            combohandle = driver.FindElement(By.XPath("//*[@id='leaveApprovers']"));
            selectitem = new SelectElement(combohandle);
            selectitem.SelectByIndex(2);

            driver.FindElement(By.XPath("//*[@id='UserComments']")).SendKeys("Test User Comments");

            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("")));
            driver.FindElement(By.XPath("//*[@id='btnCreate']")).Click();
            
        }

    }
}
