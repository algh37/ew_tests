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

2.1.3) Work with link "Privacy" on footer of the main-page emotorwerks.com.
2.1.3.1) Check presense of link (text + href).
2.1.3.2) Check ability to go on link.

2.1.4) Work with link "Cookie Policy" on footer of the main-page emotorwerks.com.
2.1.4.1) Check presense of link (text + href).
2.1.4.2) Check ability to go on link.

2.1.5) Work with link "Sitemap" on footer of the main-page emotorwerks.com.
2.1.5.1) Check presense of link (text + href).
2.1.5.2) Check ability to go on link.

======
 
Global steps:
1) Working on FireFox Browser:
1.1) Check Test-suite 1.
1.2) Check Test-suite 2.

2) Working on Chrome Browser:
2.1) Check Test-suite 1.
2.2) Check Test-suite 2.

3) Working on IE Browser:
3.1) Check Test-suite 1.
3.2) Check Test-suite 2.