# CSharp Selenium Demo
This is a demonstration of how a Selenium test suite can be written using C# and NUnit. 

The tests in this project test [this](http://automationpractice.com/index.php) site, which is a website created by the Selenium devs to act as a testing ground for aspiring automated test writers.

# Project Structure

The parts of the project you may want to checkout are as follows:

- **SeleniumTestSuiteExample**: This is the main folder, All of the following items are in here. 
- **EntryPoint.cs**: The entry point of the application.
- **PageModels**: Here you'll find the models of each webpage that is tested. 
- **TestSuites**: Here you'll find the actual tests.

# How To Run

## Prerequisites
You'll need the following to be installed in order to run this application:
- [Firefox Web Browser](https://www.mozilla.org/en-US/firefox/new/)
- [Geckodriver](https://github.com/mozilla/geckodriver/releases)
- -You'll need to add this to your system's PATH variable as explained [here](https://www.selenium.dev/documentation/getting_started/installing_browser_drivers/#adding-executables-to-your-path).
- [Visual Studio](https://visualstudio.microsoft.com/)

Once all the necessary applications are installed you can simply open SeleniumTestSuiteExample.sln in Visual Studio and click the run button.
**Note**:This test suite takes about 50 min. to run in it's entirety so you may want to comment out all but the test suites that you're interested to see in action.

