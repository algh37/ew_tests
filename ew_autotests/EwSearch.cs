using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.IO;
// using OpenQA.Selenium.Edge;

namespace ew_autotests
{
    class EwSearch
    {
        static void Main(string[] args)
        {

            // Global steps:
            // 2) Working on Chrome Browser:

            // initialize Chrome driver
            IWebDriver driver_chrome = new ChromeDriver();

            // 2.1) Check Test-suite 1.

            driver_chrome.Navigate().GoToUrl("https://google.com");

            string current_url = driver_chrome.Url;

            if (current_url == "https://www.google.com/")
            {
                NoErrorMess("Step1: Passed - Have been opened https://www.google.com/");
            }
            else
            {
                ErrorMess("Step1: Failed - Have been opened " + current_url);
            }

            IWebElement search_field = driver_chrome.FindElement(By.Name("q"));
            search_field.SendKeys("emotorwerks");

            IWebElement search_button = driver_chrome.FindElement(By.Name("btnK"));
            search_button.Submit();

            string page_number = "//*[@id=\"nav\"]/tbody/tr/td[2]";

            IWebElement search_first_page_number = driver_chrome.FindElement(By.XPath(page_number));

            string test = search_first_page_number.Text;

            // Console.WriteLine(test);

            if (test == "1")
            {
                NoErrorMess("Step2: Passed - Successfully opened 1st result page by searching word \"emotorwerks\" via google.com");
            }
            else
            {
                ErrorMess("Step2: Failed - Opened not 1st result page by searching word \"emotorwerks\" via google.com");
            }

            // 2.2) Check Test-suite 2.

            // ******

            // initialize FireFox driver
            /* IWebDriver driver_firefox = new FirefoxDriver();

            driver_firefox.Navigate().GoToUrl("https://google.com"); */

            /* initialize IE driver
            source http://selenium-release.storage.googleapis.com/index.html?path=3.141/ */
            /*const string URL_IE = "https://google.com";
            const string IE_DRIVER_PATH = @"C:\Users\afreel\source\repos\emotorwerks\ew_autotests\Browsers_cores\IE\";

            var options = new InternetExplorerOptions()
            {
                InitialBrowserUrl = URL_IE,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true
            };

            var driver_ie = new InternetExplorerDriver(IE_DRIVER_PATH, options);

            driver_ie.Navigate(); */

            // initialize Edge driver
            /* Workstaion with OS Windows 7 x64 on which imposible to install Edge browser according to: 
            https://answers.microsoft.com/en-us/ie/forum/all/microsoft-edge-browser-for-windows-7-os/49411ac0-7cc8-44d3-8c12-70d565b64ea0 */
            /* IWebDriver driver_edge = new EdgeDriver();
            driver_edge.Navigate().GoToUrl("https://google.com"); */

            // Thread.Sleep(3000);

            // driver_chrome.Quit();
            // driver_firefox.Quit();

            /* driver_ie.Close();
            driver_ie.Quit();
            driver_ie.Dispose(); */

            // driver_edge.Quit();
        }

        private static void ErrorMess(string mess)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mess);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void NoErrorMess(string mess)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mess);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
