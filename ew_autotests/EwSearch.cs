﻿using System;
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
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;

namespace ew_autotests
{
    class EwSearch
    {
        static void Main(string[] args)
        {
            // ###########################################################
            // Global steps:
            // ###########################################################

            // 1) Working on FireFox Browser:

            string languageCode_ff = "en-GB";
            var ffProfile = new FirefoxOptions();
            ffProfile.SetPreference("intl.accept_languages", languageCode_ff);

            var driver_firefox = new FirefoxDriver(ffProfile);

            // 1.1) Check Test-suite 1.
            TestSuit1(driver_firefox);

            // 1.2) Check Test-suite 2.
            TestSuit2(driver_firefox);

            // ###########################################################

            // 2) Working on Chrome Browser:

            var ChOptions = new ChromeOptions();
            string languageCode_ch = "en-GB";
            ChOptions.AddArguments("--start-maximized", "lang=" + languageCode_ch);

            // initialize Chrome driver
            var driver_chrome = new ChromeDriver(ChOptions);

            // 2.1) Check Test-suite 1.
            TestSuit1(driver_chrome);

            // 2.2) Check Test-suite 2.
            TestSuit2(driver_chrome);

            // ###########################################################

            // 3) Working on Edge Browser:

            // initialize Edge driver
            // const string URL_Edge = "https://google.com";

            /* comment this block because on workstation has installed OS = Win 7 x64 
             * on which imposible to install Edge browser according to: 
             * https://answers.microsoft.com/en-us/ie/forum/all/microsoft-edge-browser-for-windows-7-os/49411ac0-7cc8-44d3-8c12-70d565b64ea0
            */

            /*
            string current_dir_edge = Directory.GetCurrentDirectory() + "\\Browsers_cores\\Edge\\";

            Console.WriteLine(current_dir_edge);

            var EdOptions = new EdgeOptions()
            {
                // InitialBrowserUrl = URL_Edge,
                // IgnoreZoomLevel = true,
                // IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                // RequireWindowFocus = true,
                // EnsureCleanSession = true
            };

            var driver_edge = new EdgeDriver(current_dir_edge, EdOptions);

            // 3.1) Check Test-suite 1.
            TestSuit1(driver_edge);

            // 3.2) Check Test-suite 2.
            TestSuit2(driver_edge);
            */

            // ###########################################################

            // 4) Working on IE Browser:

            /* initialize IE driver
            source http://selenium-release.storage.googleapis.com/index.html?path=3.141/ */
            const string URL_IE = "https://google.com";

            string current_dir_ie = Directory.GetCurrentDirectory() + "\\Browsers_cores\\IE\\";

            Console.WriteLine(current_dir_ie);

            var IeOptions = new InternetExplorerOptions()
            {
                InitialBrowserUrl = URL_IE,
                IgnoreZoomLevel = true,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                RequireWindowFocus = true,
                EnsureCleanSession = true
            };

            var driver_ie = new InternetExplorerDriver(current_dir_ie, IeOptions);

            // 4.1) Check Test-suite 1.

            TestSuit1(driver_ie);

            // 4.2) Check Test-suite 2.
            TestSuit2(driver_ie);

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
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

        private static void TestSuit1(IWebDriver browser_driver)
        {
            // Test-suite 1: 
            // Title: Search and interacts with google.com:

            // Test-case 1.1:
            // Title: Search and analysis search results check on google service:

            // Steps:
            // 1.1.1) Open browser and go on page google.com.

            Console.WriteLine("");
            Console.WriteLine("Start of testing TestSuit1 in browser: " + browser_driver);

            browser_driver.Navigate().GoToUrl("https://www.google.com/setprefs?&submit2=%D0%97%D0%B1%D0%B5%D1%80%D0%B5%D0%B3%D1%82%D0%B8+%D0%BD%D0%B0%D0%BB%D0%B0%D1%88%D1%82%D1%83%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F&hl=en&lang=en&lr=lang_en&safeui=images&num=0&newwindow=0&gl=ZZ&region=ZZ&q=&prev=https%3A%2F%2Fwww.google.com%2F");

            browser_driver.Navigate().GoToUrl("https://www.google.com/preferences?hl=en#languages");

            IWebElement submit_pref_button = browser_driver.FindElement(By.Name("langform"));

            Thread.Sleep(3000);

            submit_pref_button.Submit();

            Thread.Sleep(3000);

            browser_driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);

            browser_driver.Navigate().GoToUrl("https://google.com");

            string current_url = browser_driver.Url;

            if (current_url == "https://www.google.com/")
            {
                NoErrorMess("Step 1.1.1: Passed - Have been opened https://www.google.com/");
            }
            else
            {
                ErrorMess(browser_driver + " Step 1.1.1: Failed - Have been opened " + current_url);
            }

            // 1.1.2) Search "emotorwerks" word via google.com.

            IWebElement search_field = browser_driver.FindElement(By.Name("q"));

            search_field.SendKeys("emotorwerks");

            search_field.SendKeys(Keys.PageDown);

            search_field.SendKeys(Keys.Tab);

            Thread.Sleep(1000);

            Actions action = new Actions(browser_driver);
            search_field.SendKeys(OpenQA.Selenium.Keys.Escape);

            IWebElement search_button = browser_driver.FindElement(By.Name("f"));
            // string xpath_search_button = "/html/body/div/div[3]/form/div[2]/div/div[3]/center/input[1]";
            // IWebElement search_button = browser_driver.FindElement(By.XPath(xpath_search_button));

            Thread.Sleep(1000);

            search_button.Submit();

            Thread.Sleep(3000);

            string xpath_page_number_elem = "//*[@id=\"nav\"]/tbody/tr/td[2]";

            IWebElement first_page_number_elem = browser_driver.FindElement(By.XPath(xpath_page_number_elem));

            string first_page_number_elem_text = first_page_number_elem.Text;

            // Console.WriteLine(test);

            if (first_page_number_elem_text == "1")
            {
                NoErrorMess("Step 1.1.2: Passed - Successfully opened 1st result page by searching word \"emotorwerks\" via google.com");
            }
            else
            {
                ErrorMess("Step 1.1.2: Failed - Opened not 1st result page by searching word \"emotorwerks\" via google.com");
            }

            // 1.1.3) Check presense of link on main-site "emotorwerks.com" on search results.

            string xpath_main_link_elem = "//*[@id=\"rso\"]/div[1]/div/div/div/div/div[1]/a";

            IWebElement main_link_elem = browser_driver.FindElement(By.XPath(xpath_main_link_elem));

            string main_link_elem_href = main_link_elem.GetAttribute("href");

            Console.WriteLine(main_link_elem_href);

            if (main_link_elem_href == "https://emotorwerks.com/")
            {
                NoErrorMess("Step 1.1.3: Passed - Successfully find 1st search result on 1st page with link \"https://emotorwerks.com/\"");
            }
            else
            {
                ErrorMess("Step 1.1.3: Failed - Unsuccessfully find 1st search result on 1st page with link \"https://emotorwerks.com/\"");
            }

            // 1.1.4) Check presense of link on wikipedia for "emotowerks.com" on search results.

            string xpath_wiki_link_elem = "//*[@id=\"rso\"]/div[2]/div/div[1]/div/div/div[1]/a";

            IWebElement wiki_link_elem = browser_driver.FindElement(By.XPath(xpath_wiki_link_elem));

            string wiki_link_elem_href = wiki_link_elem.GetAttribute("href");

            Console.WriteLine(wiki_link_elem_href);

            if (wiki_link_elem_href == "https://en.wikipedia.org/wiki/EMotorWerks")
            {
                NoErrorMess("Step 1.1.4: Passed - Successfully find 2nd search result on 1st page with link \"https://en.wikipedia.org/wiki/EMotorWerks\"");
            }
            else
            {
                ErrorMess("Step 1.1.4: Failed - Unsuccessfully find 2nd search result on 1st page with link \"https://en.wikipedia.org/wiki/EMotorWerks\"");
            }

            // 1.1.5) Check presense of block "eMotorWerks - Wikipedia" on search results.

            // 1.1.5.1 work with "Complementary results" h1 block with info from wiki
            string xpath_wiki_comp_res_elem = "//*[@id=\"rhs_block\"]/h1";

            IWebElement wiki_comp_res_elem = browser_driver.FindElement(By.XPath(xpath_wiki_comp_res_elem));

            string wiki_comp_res_elem_text = wiki_comp_res_elem.Text;

            Console.WriteLine(wiki_comp_res_elem_text);

            if (wiki_comp_res_elem_text == "Complementary results")
            {
                NoErrorMess("Step 1.1.5.1: Passed - Successfully find wikipedia block with text \"Complementary results\"");
            }
            else
            {
                ErrorMess("Step 1.1.5.1: Failed - Unsuccessfully find wikipedia block with text \"Complementary results\"");
            }

            // 1.1.5.2 work with "eMotorWerks" company name span block with info from wiki
            string xpath_wiki_company_name_elem = "//*[@id=\"rhs_block\"]/div[1]/div[1]/div/div[1]/div[2]/div[2]/div/div[1]/div/div/div[2]/div[1]/span";

            IWebElement wiki_company_name_elem = browser_driver.FindElement(By.XPath(xpath_wiki_company_name_elem));

            string wiki_company_name_elem_text = wiki_company_name_elem.Text;

            Console.WriteLine(wiki_company_name_elem_text);

            if (wiki_company_name_elem_text == "eMotorWerks")
            {
                NoErrorMess("Step 1.1.5.2: Passed - Successfully find span block with text \"eMotorWerks\" inside wikipedia block");
            }
            else
            {
                ErrorMess("Step 1.1.5.2: Failed - Unsuccessfully find span block with text \"eMotorWerks\" inside wikipedia block");
            }

            // 1.1.5.3 work with "Company name" span block with info from wiki
            string xpath_wiki_block_link_elem = "//*[@id=\"rhs_block\"]/div[1]/div[1]/div/div[1]/div[2]/div[4]/div/div[1]/div/div/div/div/span[2]/a";

            IWebElement wiki_block_link_elem = browser_driver.FindElement(By.XPath(xpath_wiki_block_link_elem));

            string wiki_block_link_elem_href = wiki_block_link_elem.GetAttribute("href");

            Console.WriteLine(wiki_block_link_elem_href);

            if (wiki_block_link_elem_href == "https://en.wikipedia.org/wiki/EMotorWerks")
            {
                NoErrorMess("Step 1.1.5.3: Passed - Successfully find a block with href \"https://en.wikipedia.org/wiki/EMotorWerks\" inside wikipedia block");
            }
            else
            {
                ErrorMess("Step 1.1.5.3: Failed - Unsuccessfully find a block with href \"https://en.wikipedia.org/wiki/EMotorWerks\" inside wikipedia block");
            }

            Console.WriteLine("");
            Console.WriteLine("Finish of testing TestSuit1 in browser: " + browser_driver);
        }

        private static void TestSuit2(IWebDriver browser_driver)
        {
            // Test - suite 2:
            // Title: Search and interacts with emotorwerks.com:

            // Test -case 2.1:
            // Title: Analysis and interacts of footer links on the main - page emotorwerks.com:

            // Steps:
            // 2.1.1) Go on page emotorwerks.com.

            Console.WriteLine("");
            Console.WriteLine("Start of testing TestSuit2 in browser: " + browser_driver);

            string main_link_elem_href = "https://emotorwerks.com/";

            browser_driver.Navigate().GoToUrl(main_link_elem_href);

            string em_current_url = browser_driver.Url;

            if (em_current_url == "https://emotorwerks.com/")
            {
                NoErrorMess("Step 2.1.1: Passed - Have been opened https://emotorwerks.com/");
            }
            else
            {
                ErrorMess("Step 2.1.1: Failed - Have been opened " + em_current_url);
            }

            // 2.1.2) Work with link "Return & refund policy" on footer of the main - page emotorwerks.com.

            // 2.1.2.1) Check presense of link (text + href).

            string xpath_em_footer_ret_policy_elem = "/html/body/div[1]/div[5]/div[3]/div[1]/div[1]/ul/li[1]/a";

            IWebElement em_footer_ret_policy_elem = browser_driver.FindElement(By.XPath(xpath_em_footer_ret_policy_elem));

            string em_footer_ret_policy_elem_href = em_footer_ret_policy_elem.GetAttribute("href");

            Console.WriteLine(em_footer_ret_policy_elem_href);

            if (em_footer_ret_policy_elem_href == "https://emotorwerks.com/return-and-refund-policy")
            {
                NoErrorMess("Step 2.1.2.1.1: Passed - Successfully find footer link \"Return & refund policy\" with href \"https://emotorwerks.com/return-and-refund-policy\"");
            }
            else
            {
                ErrorMess("Step 2.1.2.1.1: Failed - Unsuccessfully find footer link \"Return & refund policy\" with href \"https://emotorwerks.com/return-and-refund-policy\"");
            }

            string em_footer_ret_policy_elem_text = em_footer_ret_policy_elem.Text;

            Console.WriteLine(em_footer_ret_policy_elem_text);

            if (em_footer_ret_policy_elem_text == "Return & refund policy")
            {
                NoErrorMess("Step 2.1.2.1.2: Passed - Successfully find footer link with text \"Return & refund policy\"");
            }
            else
            {
                ErrorMess("Step 2.1.2.1.2: Failed - Unsuccessfully find footer link with text \"Return & refund policy\"");
            }

            // 2.1.2.2) Check ability to go on link.

            // IWebDriver driver; // assume assigned elsewhere
            // driver = null;
            // IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            // js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");

            em_footer_ret_policy_elem.SendKeys(Keys.PageDown);

            Thread.Sleep(2000);

            string xpath_em_footer_cookies_elem = "//*[@id=\"pwebbox204_toggler\"]/i";

            IWebElement em_footer_cookies_elem = browser_driver.FindElement(By.XPath(xpath_em_footer_cookies_elem));

            em_footer_cookies_elem.Click();

            em_footer_ret_policy_elem.Click();

            // 2.1.2.3) Check H1 of the page.

            string xpath_em_ret_policy_page_elem = "/html/body/div[1]/div[2]/div/div[2]/div[1]/h1";

            IWebElement em_ret_policy_page_elem = browser_driver.FindElement(By.XPath(xpath_em_ret_policy_page_elem));

            string em_ret_policy_page_elem_text = em_ret_policy_page_elem.Text;

            Console.WriteLine(em_ret_policy_page_elem_text);

            if (em_ret_policy_page_elem_text == "Return and Refund Policy")
            {
                NoErrorMess("Step 2.1.2.3: Passed - find expected H1 of page and equal to \"Return and Refund Policy\"");
            }
            else
            {
                ErrorMess("Step 2.1.2.3: Failed - find not expected H1 of page and not equal to \"Return and Refund Policy\"");
            }

            browser_driver.Navigate().Back();

            // 2.1.3) Work with link "Privacy" on footer of the main - page emotorwerks.com.
            // 2.1.3.1) Check presense of link (text + href).
            string xpath_em_footer_pr_privacy_elem = "/html/body/div[1]/div[5]/div[3]/div[1]/div[1]/ul/li[2]/a";

            IWebElement em_footer_pr_privacy_elem = browser_driver.FindElement(By.XPath(xpath_em_footer_pr_privacy_elem));

            string em_footer_pr_privacy_elem_href = em_footer_pr_privacy_elem.GetAttribute("href");

            Console.WriteLine(em_footer_pr_privacy_elem_href);

            if (em_footer_pr_privacy_elem_href == "https://emotorwerks.com/privacy-policy")
            {
                NoErrorMess("Step 2.1.3.1.1: Passed - Successfully find footer link \"Privacy\" with href \"https://emotorwerks.com/privacy-policy\"");
            }
            else
            {
                ErrorMess("Step 2.1.3.1.1: Failed - Unsuccessfully find footer link \"Privacy\" with href \"https://emotorwerks.com/privacy-policy\"");
            }

            string em_footer_pr_privacy_elem_text = em_footer_pr_privacy_elem.Text;

            Console.WriteLine(em_footer_pr_privacy_elem_text);

            if (em_footer_pr_privacy_elem_text == "Privacy")
            {
                NoErrorMess("Step 2.1.3.1.2: Passed - Successfully find footer link with text \"Privacy\"");
            }
            else
            {
                ErrorMess("Step 2.1.3.1.2: Failed - Unsuccessfully find footer link with text \"Privacy\"");
            }

            // 2.1.3.2) Check ability to go on link.
            em_footer_pr_privacy_elem.Click();

            // 2.1.3.3) Check H1 of the page.
            string xpath_em_footer_pr_privacy_page_elem = "/html/body/div[1]/div[2]/div/div[2]/div/div[1]/div/h1";

            Thread.Sleep(2000);

            IWebElement em_footer_pr_privacy_page_elem = browser_driver.FindElement(By.XPath(xpath_em_footer_pr_privacy_page_elem));

            string em_footer_pr_privacy_page_elem_text = em_footer_pr_privacy_page_elem.Text;

            Console.WriteLine(em_footer_pr_privacy_page_elem_text);

            if (em_footer_pr_privacy_page_elem_text == "Privacy Policy")
            {
                NoErrorMess("Step 2.1.3.3: Passed - find expected H1 of page and equal to \"Privacy Policy\"");
            }
            else
            {
                ErrorMess("Step 2.1.3.3: Failed - find not expected H1 of page and not equal to \"Privacy Policy\"");
            }

            browser_driver.Navigate().Back();

            // 2.1.4) Work with link "Cookie Policy" on footer of the main - page emotorwerks.com.
            // 2.1.4.1) Check presense of link (text + href).

            string xpath_em_footer_ck_privacy_elem = "/html/body/div[1]/div[5]/div[3]/div[1]/div[1]/ul/li[3]/a";

            IWebElement em_footer_ck_privacy_elem = browser_driver.FindElement(By.XPath(xpath_em_footer_ck_privacy_elem));

            string em_footer_ck_privacy_elem_href = em_footer_ck_privacy_elem.GetAttribute("href");

            Console.WriteLine(em_footer_ck_privacy_elem_href);

            if (em_footer_ck_privacy_elem_href == "https://emotorwerks.com/cookie-policy")
            {
                NoErrorMess("Step 2.1.4.1.1: Passed - Successfully find footer link \"Cookie Policy\" with href \"https://emotorwerks.com/cookie-policy\"");
            }
            else
            {
                ErrorMess("Step 2.1.4.1.1: Failed - Unsuccessfully find footer link \"Cookie Policy\" with href \"https://emotorwerks.com/cookie-policy\"");
            }

            string em_footer_ck_privacy_elem_text = em_footer_ck_privacy_elem.Text;

            Console.WriteLine(em_footer_ck_privacy_elem_text);

            if (em_footer_ck_privacy_elem_text == "Cookie Policy")
            {
                NoErrorMess("Step 2.1.4.1.2: Passed - Successfully find footer link with text \"Cookie Policy\"");
            }
            else
            {
                ErrorMess("Step 2.1.4.1.2: Failed - Unsuccessfully find footer link with text \"Cookie Policy\"");
            }

            // 2.1.4.2) Check ability to go on link.
            em_footer_ck_privacy_elem.SendKeys(Keys.PageDown);

            em_footer_ck_privacy_elem.Click();

            // 2.1.4.3) Check H1 of the page.

            string xpath_em_h1_ck_privacy_page_elem = "/html/body/div[1]/div[2]/div/div[2]/div[1]/h1";

            IWebElement em_h1_ck_privacy_page_elem = browser_driver.FindElement(By.XPath(xpath_em_h1_ck_privacy_page_elem));

            string em_h1_ck_privacy_page_elem_text = em_h1_ck_privacy_page_elem.Text;

            Console.WriteLine(em_h1_ck_privacy_page_elem_text);

            if (em_h1_ck_privacy_page_elem_text == "Cookie Page")
            {
                NoErrorMess("Step 2.1.4.3: Passed - find expected H1 of page and equal to \"Cookie Page\"");
            }
            else
            {
                ErrorMess("Step 2.1.4.3: Failed - find not expected H1 of page and not equal to \"Cookie Page\"");
            }

            browser_driver.Navigate().Back();

            // 2.1.5) Work with link "Sitemap" on footer of the main - page emotorwerks.com.
            // 2.1.5.1) Check presense of link (text + href).

            string xpath_em_footer_sitemap_elem = "/html/body/div[1]/div[5]/div[3]/div[1]/div[1]/ul/li[4]/a";

            IWebElement em_footer_sitemap_elem = browser_driver.FindElement(By.XPath(xpath_em_footer_sitemap_elem));

            string em_footer_sitemap_elem_href = em_footer_sitemap_elem.GetAttribute("href");

            Console.WriteLine(em_footer_sitemap_elem_href);

            if (em_footer_sitemap_elem_href == "https://emotorwerks.com/sitemap")
            {
                NoErrorMess("Step 2.1.5.1.1: Passed - Successfully find footer link \"Sitemap\" with href \"https://emotorwerks.com/sitemap\"");
            }
            else
            {
                ErrorMess("Step 2.1.5.1.1: Failed - Unsuccessfully find footer link \"Sitemap\" with href \"https://emotorwerks.com/sitemap\"");
            }

            string em_footer_sitemap_elem_text = em_footer_sitemap_elem.Text;

            Console.WriteLine(em_footer_sitemap_elem_text);

            if (em_footer_sitemap_elem_text == "Sitemap")
            {
                NoErrorMess("Step 2.1.5.1.2: Passed - Successfully find footer link with text \"Sitemap\"");
            }
            else
            {
                ErrorMess("Step 2.1.5.1.2: Failed - Unsuccessfully find footer link with text \"Sitemap\"");
            }

            // 2.1.5.2) Check ability to go on link.

            em_footer_sitemap_elem.Click();

            // 2.1.5.3) Check H1 of the page.

            string xpath_em_h1_sitemap_page_elem = "//*[@id=\"jmap_sitemap\"]/h1";

            IWebElement em_h1_sitemap_page_elem = browser_driver.FindElement(By.XPath(xpath_em_h1_sitemap_page_elem));

            string em_h1_sitemap_page_elem_text = em_h1_sitemap_page_elem.Text;

            Console.WriteLine(em_h1_sitemap_page_elem_text);

            if (em_h1_sitemap_page_elem_text == "Sitemap")
            {
                NoErrorMess("Step 2.1.5.3: Passed - find expected H1 of page and equal to \"Sitemap\"");
            }
            else
            {
                ErrorMess("Step 2.1.5.3: Failed - find not expected H1 of page and not equal to \"Sitemap\"");
            }

            Console.WriteLine("");
            Console.WriteLine("Finish of testing TestSuit2 in browser: " + browser_driver);

            browser_driver.Close();
            browser_driver.Quit();
            browser_driver.Dispose();
        }
    }
}
