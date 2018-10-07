using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    namespace UnitTestProject1
    {
        [TestClass]
        public class WinAppTest : WinAppSession
        {
            [TestMethod]
            public void GridEnterText()
            {
                // Type mixed text and apply shift modifier to 7890_ to generate corresponding symbols
                Thread.Sleep(TimeSpan.FromSeconds(2));
                AppiumWebElement firstNameCell = dataGrid.FindElementByName("Row 0").FindElementByName("Name Row 0");
                firstNameCell.Click();
                firstNameCell.SendKeys("abcdeABCDE 12345" + Keys.Shift + "7890-" + Keys.Shift + @"!@#$%");
                firstNameCell.SendKeys(Keys.Enter);
                Assert.AreEqual(@"abcdeABCDE 12345&*()_!@#$%", firstNameCell.Text);
            }

            [TestMethod]
            public void DataGridKeyBoardShortcuts()
            {
                // Type a known text sequence, select, copy, and paste it three times
                AppiumWebElement firstIdCell = dataGrid.FindElementByName("Row 0").FindElementByName("Id Row 0");
                firstIdCell.SendKeys("789");
                firstIdCell.SendKeys(Keys.Control + "a" + Keys.Control); // Select all using Ctrl + A keyboard shortcut
                firstIdCell.SendKeys(Keys.Control + "c" + Keys.Control); // Copy using Ctrl + C keyboard shortcut
                firstIdCell.SendKeys(Keys.Control + "vvv" + Keys.Control); // Paste 3 times using Ctrl + V keyboard shortcut
                firstIdCell.SendKeys(Keys.Enter);
                Assert.AreEqual("789789789", firstIdCell.Text);
            }

            [ClassInitialize]
            public static void ClassInitialize(TestContext context)
            {
                Setup(context);
            }

            [ClassCleanup]
            public static void ClassCleanup()
            {
                TearDown();
            }
        }
    }

}
