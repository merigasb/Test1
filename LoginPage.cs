using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Shyam_Test
{
    class LoginPage
    {
        IWebDriver driver;
        WebDriverWait wait;

        [FindsBy(How = How.Id, Using = "txtUserName")]
        IWebElement Txt_Login_UserName;

        [FindsBy(How = How.Name, Using = "password")]
        IWebElement Txt_Login_Password;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/section/div/form/div/div[6]/div/button")]
        IWebElement Btn_Login;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
            wait = new WebDriverWait(driver, (TimeSpan.FromMilliseconds(5000)));
        }

        public void EnterUserName(string name)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("txtUserName")));
            Txt_Login_UserName.Clear();
            Txt_Login_UserName.SendKeys(name);
        }

        public void EnterPassword(string password)
        {
            Txt_Login_Password.Clear();
            Txt_Login_Password.SendKeys(password);
        }

        public void CllickOnLogin()
        {
            Btn_Login.Click();
        }

        public HomePage Login(string username, string password)
        {
            EnterUserName(username);
            EnterPassword(password);
            CllickOnLogin();

            return new HomePage(driver);
        }

    }
}
