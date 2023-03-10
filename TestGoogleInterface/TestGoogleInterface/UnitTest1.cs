using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class UntitledTestCase
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        public object TimeUnit { get; private set; }

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            // arrange
            var option = new ChromeOptions()
            {
                BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
            };

            //option.AddArgument("--headless");
            driver = new ChromeDriver(option);
            //driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        public void Screenshot(string fileName)
        {
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot screenshot = camera.GetScreenshot();
            screenshot.SaveAsFile(fileName);
        }


        [TestMethod]
        public void TestOpenPageURL()
        {
            // act
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Navigate().GoToUrl("https://www.youtube.com/");

            // assert - verifica se o titulo da pagina esta coerente com o esperado
            Assert.AreEqual("YouTube", driver.Title);

            // screenshot 
            Screenshot("testPageYoutubeURL.png");
        }

        [TestMethod]
        public void TestOpenPageClick()
        {
            // act
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.Name("q")).Clear();
            driver.FindElement(By.Name("q")).SendKeys("mdn web docs");
            driver.FindElement(By.XPath("//img[@alt='Google']")).Click();
            driver.FindElement(By.XPath("//div[4]/center/input")).Click();
            driver.FindElement(By.XPath("//div[@id='rso']/div/div/div/div/div/div/div/div/div/a/h3")).Click();
            driver.Navigate().GoToUrl("https://developer.mozilla.org/pt-BR/");

            // assert - verifica se o titulo da pagina esta coerente com o esperado
            Assert.AreEqual("MDN Web Docs", driver.Title);

            // screenshot
            Screenshot("testPageMDNClick.png");
        }

        [TestMethod]
        public void TestClickSobreGoogle()
        {
            // act
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.LinkText("Sobre")).Click();
            driver.Navigate().GoToUrl("https://about.google/?utm_source=google-BR&utm_medium=referral&utm_campaign=hp-footer&fg=1");

            // assert - verifica se existe o texto padrao da pagina
            Assert.IsNotNull(driver.FindElement(By.XPath("//*[@id=\"page-content\"]/section[1]/div/div[2]/h1")));

            // screenshot 
            Screenshot("testClickSobreGoogle.png");
        }

        [TestMethod]
        public void TestIcon()
        {
            // act
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.CssSelector("svg.gb_0e > path")).Click();
            driver.Navigate().GoToUrl("https://meet.google.com/?hs=197&pli=1&authuser=0");

            // assert - verifica se existe o botao de "iniciar uma reuniao"
            Assert.IsNotNull(driver.FindElement(By.XPath("//*[@id=\"page-content\"]/section[1]/div/div[1]/div[2]/div/a/button")));

            // screenshot 
            Screenshot("testIcon.png");
        }

        [TestMethod]
        public void TestGoogleTheme()
        {
            // act - troca o tema para dark
            driver.Navigate().GoToUrl("https://www.google.com/?pccc=1");

                // screenshot - anter de mudar o tema
                Screenshot("BeforeTestGoogleTheme.png");

            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Termos'])[1]/following::div[2]")).Click();
            driver.FindElement(By.XPath("//div[@id='YUIDDb']/div/div")).Click();

            // armazena o atributo da tag meta (onde fica especificado o tema) na variavel atrContent
            IWebElement meta = driver.FindElement(By.XPath("/html/head/meta[2]"));
            String atrContent = meta.GetAttribute("content");

            // assert - verifica se o tema esta dark
            Assert.IsTrue("dark" == atrContent || "origin" == atrContent);

            // screenshot - apos mudar o tema
            Screenshot("AfterTestGoogleTheme.png");
        }

        [TestMethod]
        public void TestInvalidURL()
        {
            // act - insere url invalida
            driver.Navigate().GoToUrl("https://www.google.com/invalid-url");

            // assert - verifica se a mensagem de erro existe
            Assert.IsNotNull(driver.FindElement(By.XPath("/html/body/p[1]/ins")));

            // screenshot
            Screenshot("testInvalidURL.png");
        }

        [TestMethod]
        public void TestGoogleLens()
        {
            // act - envia a url da imagem para o google lens
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath("//img[@alt='Pesquisa com a c??mera']")).Click();
            driver.FindElement(By.XPath("//div[@id='ow6']/div[3]/c-wiz/div[2]/div/div[3]/div[2]/c-wiz/div[2]/input")).Click();
            driver.Navigate().GoToUrl("https://lens.google.com/upload?hl=pt-BR&re=df&st=1672434425512&ep=gsbubb");
            driver.Navigate().GoToUrl("https://lens.google.com/search?p=AXAp4wje2gHEz-BXtlFvsjqbZot8AY6gIyEWDRHFECPaAD0L0bK2Ag6-zbjt9S5wqYx-sWsEzlcG1pumMhzR3nEfJ9i8p91h9WqHdZqXpYgJM7_B6mP8lCweLtOmtfXh2UEESsLN9J9sChi1MCNw5t6Bwvi9PuNHs6bjjeqmwqdV9JIKC2ZIONYcW0Hkf1AuQtKrJx11XkkdEPs6LEnYXqexPBnOWFysHTdkWj6BqSe47-bBtMOE8-n4XH8gMzGAF7hrWRkHWb2ueUtA-F89L-ABeQ6Rw8izlNDjmfR1cHrNpv8GL18u9BoNAqxMbbz1tLA%3D&ep=gsbubb&hl=pt-BR&re=df&st=1672434425512");
            driver.Navigate().GoToUrl("https://lens.google.com/search?p=AXAp4wje2gHEz-BXtlFvsjqbZot8AY6gIyEWDRHFECPaAD0L0bK2Ag6-zbjt9S5wqYx-sWsEzlcG1pumMhzR3nEfJ9i8p91h9WqHdZqXpYgJM7_B6mP8lCweLtOmtfXh2UEESsLN9J9sChi1MCNw5t6Bwvi9PuNHs6bjjeqmwqdV9JIKC2ZIONYcW0Hkf1AuQtKrJx11XkkdEPs6LEnYXqexPBnOWFysHTdkWj6BqSe47-bBtMOE8-n4XH8gMzGAF7hrWRkHWb2ueUtA-F89L-ABeQ6Rw8izlNDjmfR1cHrNpv8GL18u9BoNAqxMbbz1tLA%3D&ep=gsbubb&hl=pt-BR&re=df#lns=W251bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsIkVrY0tKREF5T0RNNFlXRmxMVFk1WkRndE5EWTVNaTFoWldRMExUZzJNalZsWWpRek5UTXlZeElmTURoTmRUTnhRMkp6WlVsUmEwSnFYMDVEVm1OblVERlNlbU5LVGxab1p3PT0iXQ==");

            // armazena o titulo da pagina
            IWebElement title = driver.FindElement(By.XPath("/html/head/title"));
            String text = title.GetAttribute("innerHTML");

            // assert - verifica se o titulo da pagina esta coerente
            Assert.IsTrue("Google Lens" == text);

            //Console.WriteLine(text);

            // screenshot
            Screenshot("testGoogleLens.png");
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}