using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Shyam_Test
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://test-erms.azurewebsites.net/");
            driver.Manage().Window.Maximize();

            //Creating Test login Page Objects
            LoginPage login = new LoginPage(driver);
            HomePage home;
            MyLeaves leave;

            home = login.Login("mobitest6","test123");
            leave =  home.GotoLeavePage();
            leave.ApplyLeave();
            //Creating Test Home Page Objects
            


        }
    }
}
