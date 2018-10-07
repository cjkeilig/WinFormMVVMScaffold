using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{

    public class WinAppSession
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private static string WinAppId = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\..\..\..\WindowsFormsApplication1\bin\Debug\WindowsFormsApplication1.exe";
//@"C:\Users\unouser\Documents\visual studio 2015\Projects\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\WindowsFormsApplication1.exe";

        protected static WindowsDriver<WindowsElement> session;
        protected static WindowsElement dataGrid;

        public static void Setup(TestContext context)
        {
            // Launch a new instance of Winform application
            if (session == null)
            {
                // Create a new session to launch Winform application
                DesiredCapabilities appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("app", WinAppId);
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                Assert.IsNotNull(session);
                Assert.IsNotNull(session.SessionId);

                // Verify that Winform is started with default title
                Assert.AreEqual("Form1", session.Title);

                // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);

                // Keep track of the data grid view to be used throughout the session
                dataGrid = session.FindElementByClassName("WindowsForms10.Window.8.app.0.3551b1b_r11_ad1");
                Assert.IsNotNull(dataGrid);
            }
        }

        public static void TearDown()
        {
            // Close the application and delete the session
            if (session != null)
            {
                session.Close();

                try
                {
                    // Dismiss Save dialog if it is blocking the exit
                    session.FindElementByName("Don't Save").Click();
                }
                catch { }

                session.Quit();
                session = null;
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            // Select all text and delete to clear the edit box
            //dataGrid.SendKeys(Keys.Control + "a" + Keys.Control);
            //dataGrid.SendKeys(Keys.Delete);
            //Assert.AreEqual(string.Empty, dataGrid.Text);
        }
    }
}
