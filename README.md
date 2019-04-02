# ew_tests

AutoTests for automation requirements from task = TestLab.txt

Language: C#
Environment: 
	Testing framework: Selenium Webdriver
	OS: Win7 x64 Ultimate
	Browsers: FireFox, Chrome, IE*

\*IE = on OS = Win 7 it is possible to use IE not Edge according to: 
https://answers.microsoft.com/en-us/ie/forum/all/microsoft-edge-browser-for-windows-7-os/49411ac0-7cc8-44d3-8c12-70d565b64ea0

	Test-suites:
=============

	Test-suite 1: 
Title: Search and interacts with google.com:

Test-case 1.1:
Title: Search and analysis search results check on google service:

Steps:
1.1.1) Open browser and go on page google.com.
1.1.2) Search "emotorwerks" word via google.com.
1.1.3) Check presense of link on main-site "emotorwerks.com" on search results.
1.1.4) Check presense of link on wikipedia for "emotowerks.com" on search results.
1.1.5) Check presense of block "eMotorWerks - Wikipedia" on search results.

=====

	Test-suite 2:
Title: Search and interacts with emotorwerks.com:

Test-case 2.1:
Title: Analysis and interacts of footer links on the main-page emotorwerks.com:

Steps:
2.1.1) Go on page emotorwerks.com.

2.1.2) Work with link "Return & refund policy" on footer of the main-page emotorwerks.com.
2.1.2.1) Check presense of link (text + href).
2.1.2.2) Check ability to go on link.
2.1.2.3) Check H1 of the page.

2.1.3) Work with link "Privacy" on footer of the main-page emotorwerks.com.
2.1.3.1) Check presense of link (text + href).
2.1.3.2) Check ability to go on link.
2.1.3.3) Check H1 of the page.

2.1.4) Work with link "Cookie Policy" on footer of the main-page emotorwerks.com.
2.1.4.1) Check presense of link (text + href).
2.1.4.2) Check ability to go on link.
2.1.4.3) Check H1 of the page.

2.1.5) Work with link "Sitemap" on footer of the main-page emotorwerks.com.
2.1.5.1) Check presense of link (text + href).
2.1.5.2) Check ability to go on link.
2.1.5.3) Check H1 of the page.

======
 
Global steps:
1) Working on FireFox Browser:
1.1) Check Test-suite 1.
1.2) Check Test-suite 2.

2) Working on Chrome Browser:
2.1) Check Test-suite 1.
2.2) Check Test-suite 2.

3) Working on Edge Browser:
3.1) Check Test-suite 1.
3.2) Check Test-suite 2.

4) Working on IE Browser:
4.1) Check Test-suite 1.
4.2) Check Test-suite 2.

======

Example of log from console with all passed Tests-suites 1 + 2:

======

1554209955889   mozrunner::runner       INFO    Running command: "C:\\Program Fi
les (x86)\\Mozilla Firefox\\firefox.exe" "-marionette" "-foreground" "-no-remote
" "-profile" "C:\\Users\\afreel\\AppData\\Local\\Temp\\rust_mozprofile.uWtqxlz7h
C6i"

Start of testing TestSuit1 in browser: OpenQA.Selenium.Firefox.FirefoxDriver
Step 1.1.1: Passed - Have been opened https://www.google.com/
Step 1.1.2: Passed - Successfully opened 1st result page by searching word "emot
orwerks" via google.com
https://emotorwerks.com/
Step 1.1.3: Passed - Successfully find 1st search result on 1st page with link "
https://emotorwerks.com/"
https://en.wikipedia.org/wiki/EMotorWerks
Step 1.1.4: Passed - Successfully find 2nd search result on 1st page with link "
https://en.wikipedia.org/wiki/EMotorWerks"
Complementary results
Step 1.1.5.1: Passed - Successfully find wikipedia block with text "Complementar
y results"
eMotorWerks
Step 1.1.5.2: Passed - Successfully find span block with text "eMotorWerks" insi
de wikipedia block
https://en.wikipedia.org/wiki/EMotorWerks
Step 1.1.5.3: Passed - Successfully find a block with href "https://en.wikipedia
.org/wiki/EMotorWerks" inside wikipedia block

Finish of testing TestSuit1 in browser: OpenQA.Selenium.Firefox.FirefoxDriver

Start of testing TestSuit2 in browser: OpenQA.Selenium.Firefox.FirefoxDriver
Step 2.1.1: Passed - Have been opened https://emotorwerks.com/
https://emotorwerks.com/return-and-refund-policy
Step 2.1.2.1.1: Passed - Successfully find footer link "Return & refund policy"
with href "https://emotorwerks.com/return-and-refund-policy"
Return & refund policy
Step 2.1.2.1.2: Passed - Successfully find footer link with text "Return & refun
d policy"
Return and Refund Policy
Step 2.1.2.3: Passed - find expected H1 of page and equal to "Return and Refund
Policy"
https://emotorwerks.com/privacy-policy
Step 2.1.3.1.1: Passed - Successfully find footer link "Privacy" with href "http
s://emotorwerks.com/privacy-policy"
Privacy
Step 2.1.3.1.2: Passed - Successfully find footer link with text "Privacy"
Privacy Policy
Step 2.1.3.3: Passed - find expected H1 of page and equal to "Privacy Policy"
https://emotorwerks.com/cookie-policy
Step 2.1.4.1.1: Passed - Successfully find footer link "Cookie Policy" with href
 "https://emotorwerks.com/cookie-policy"
Cookie Policy
Step 2.1.4.1.2: Passed - Successfully find footer link with text "Cookie Policy"

Cookie Page
Step 2.1.4.3: Passed - find expected H1 of page and equal to "Cookie Page"
https://emotorwerks.com/sitemap
Step 2.1.5.1.1: Passed - Successfully find footer link "Sitemap" with href "http
s://emotorwerks.com/sitemap"
Sitemap
Step 2.1.5.1.2: Passed - Successfully find footer link with text "Sitemap"
Sitemap
Step 2.1.5.3: Passed - find expected H1 of page and equal to "Sitemap"

Finish of testing TestSuit2 in browser: OpenQA.Selenium.Firefox.FirefoxDriver
Starting ChromeDriver 73.0.3683.68 (47787ec04b6e38e22703e856e101e840b65afe72) on
 port 56186
Only local connections are allowed.
Please protect ports used by ChromeDriver and related test frameworks to prevent
 access by malicious code.

DevTools listening on ws://127.0.0.1:56190/devtools/browser/303911f5-8f75-4131-b
20b-0e1ccb5e6b9b
[0402/160023.662:ERROR:gl_surface_egl.cc(543)] EGL Driver message (Critical) egl
Initialize: No available renderers.
[0402/160023.662:ERROR:gl_surface_egl.cc(957)] eglInitialize D3D9 failed with er
ror EGL_NOT_INITIALIZED
[0402/160023.663:ERROR:gl_initializer_win.cc(196)] GLSurfaceEGL::InitializeOneOf
f failed.
[0402/160023.666:ERROR:viz_main_impl.cc(169)] Exiting GPU process due to errors
during initialization
[0402/160023.785:ERROR:command_buffer_proxy_impl.cc(124)] ContextResult::kTransi
entFailure: Failed to send GpuChannelMsg_CreateCommandBuffer.

Start of testing TestSuit1 in browser: OpenQA.Selenium.Chrome.ChromeDriver
Step 1.1.1: Passed - Have been opened https://www.google.com/
Step 1.1.2: Passed - Successfully opened 1st result page by searching word "emot
orwerks" via google.com
https://emotorwerks.com/
Step 1.1.3: Passed - Successfully find 1st search result on 1st page with link "
https://emotorwerks.com/"
https://en.wikipedia.org/wiki/EMotorWerks
Step 1.1.4: Passed - Successfully find 2nd search result on 1st page with link "
https://en.wikipedia.org/wiki/EMotorWerks"
Complementary results
Step 1.1.5.1: Passed - Successfully find wikipedia block with text "Complementar
y results"
eMotorWerks
Step 1.1.5.2: Passed - Successfully find span block with text "eMotorWerks" insi
de wikipedia block
https://en.wikipedia.org/wiki/EMotorWerks
Step 1.1.5.3: Passed - Successfully find a block with href "https://en.wikipedia
.org/wiki/EMotorWerks" inside wikipedia block

Finish of testing TestSuit1 in browser: OpenQA.Selenium.Chrome.ChromeDriver

Start of testing TestSuit2 in browser: OpenQA.Selenium.Chrome.ChromeDriver
Step 2.1.1: Passed - Have been opened https://emotorwerks.com/
https://emotorwerks.com/return-and-refund-policy
Step 2.1.2.1.1: Passed - Successfully find footer link "Return & refund policy"
with href "https://emotorwerks.com/return-and-refund-policy"
Return & refund policy
Step 2.1.2.1.2: Passed - Successfully find footer link with text "Return & refun
d policy"
Return and Refund Policy
Step 2.1.2.3: Passed - find expected H1 of page and equal to "Return and Refund
Policy"
https://emotorwerks.com/privacy-policy
Step 2.1.3.1.1: Passed - Successfully find footer link "Privacy" with href "http
s://emotorwerks.com/privacy-policy"
Privacy
Step 2.1.3.1.2: Passed - Successfully find footer link with text "Privacy"
Privacy Policy
Step 2.1.3.3: Passed - find expected H1 of page and equal to "Privacy Policy"
https://emotorwerks.com/cookie-policy
Step 2.1.4.1.1: Passed - Successfully find footer link "Cookie Policy" with href
 "https://emotorwerks.com/cookie-policy"
Cookie Policy
Step 2.1.4.1.2: Passed - Successfully find footer link with text "Cookie Policy"

Cookie Page
Step 2.1.4.3: Passed - find expected H1 of page and equal to "Cookie Page"
https://emotorwerks.com/sitemap
Step 2.1.5.1.1: Passed - Successfully find footer link "Sitemap" with href "http
s://emotorwerks.com/sitemap"
Sitemap
Step 2.1.5.1.2: Passed - Successfully find footer link with text "Sitemap"
Sitemap
Step 2.1.5.3: Passed - find expected H1 of page and equal to "Sitemap"

Finish of testing TestSuit2 in browser: OpenQA.Selenium.Chrome.ChromeDriver
C:\Users\afreel\Source\Repos\ew_tests\ew_autotests\bin\Debug\Browsers_cores\IE\
Started InternetExplorerDriver server (64-bit)
3.141.5.0
Listening on port 56284
Only local connections are allowed

Start of testing TestSuit1 in browser: OpenQA.Selenium.IE.InternetExplorerDriver

Step 1.1.1: Passed - Have been opened https://www.google.com/
Step 1.1.2: Passed - Successfully opened 1st result page by searching word "emot
orwerks" via google.com
https://emotorwerks.com/
Step 1.1.3: Passed - Successfully find 1st search result on 1st page with link "
https://emotorwerks.com/"
https://en.wikipedia.org/wiki/EMotorWerks
Step 1.1.4: Passed - Successfully find 2nd search result on 1st page with link "
https://en.wikipedia.org/wiki/EMotorWerks"
Complementary results
Step 1.1.5.1: Passed - Successfully find wikipedia block with text "Complementar
y results"
eMotorWerks
Step 1.1.5.2: Passed - Successfully find span block with text "eMotorWerks" insi
de wikipedia block
https://en.wikipedia.org/wiki/EMotorWerks
Step 1.1.5.3: Passed - Successfully find a block with href "https://en.wikipedia
.org/wiki/EMotorWerks" inside wikipedia block

Finish of testing TestSuit1 in browser: OpenQA.Selenium.IE.InternetExplorerDrive
r

Start of testing TestSuit2 in browser: OpenQA.Selenium.IE.InternetExplorerDriver

Step 2.1.1: Passed - Have been opened https://emotorwerks.com/
https://emotorwerks.com/return-and-refund-policy
Step 2.1.2.1.1: Passed - Successfully find footer link "Return & refund policy"
with href "https://emotorwerks.com/return-and-refund-policy"
Return & refund policy
Step 2.1.2.1.2: Passed - Successfully find footer link with text "Return & refun
d policy"
Return and Refund Policy
Step 2.1.2.3: Passed - find expected H1 of page and equal to "Return and Refund
Policy"
https://emotorwerks.com/privacy-policy
Step 2.1.3.1.1: Passed - Successfully find footer link "Privacy" with href "http
s://emotorwerks.com/privacy-policy"
Privacy
Step 2.1.3.1.2: Passed - Successfully find footer link with text "Privacy"
Privacy Policy
Step 2.1.3.3: Passed - find expected H1 of page and equal to "Privacy Policy"
https://emotorwerks.com/cookie-policy
Step 2.1.4.1.1: Passed - Successfully find footer link "Cookie Policy" with href
 "https://emotorwerks.com/cookie-policy"
Cookie Policy
Step 2.1.4.1.2: Passed - Successfully find footer link with text "Cookie Policy"

Cookie Page
Step 2.1.4.3: Passed - find expected H1 of page and equal to "Cookie Page"
https://emotorwerks.com/sitemap
Step 2.1.5.1.1: Passed - Successfully find footer link "Sitemap" with href "http
s://emotorwerks.com/sitemap"
Sitemap
Step 2.1.5.1.2: Passed - Successfully find footer link with text "Sitemap"
Sitemap
Step 2.1.5.3: Passed - find expected H1 of page and equal to "Sitemap"

Finish of testing TestSuit2 in browser: OpenQA.Selenium.IE.InternetExplorerDrive
r
Press enter to close...

======