using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SeleniumGrid
{
    public class TestBase : IDisposable
    {
        public IWebDriver Driver { get; set; }
        public string hubGridUrl = "http://localhost:4444/";
        public TimeSpan timeSpan = new TimeSpan(0, 3, 0);

        public void SetUpRemoteDriver(DriverOptions options)
        {
            Driver = new RemoteWebDriver(
                new Uri(hubGridUrl), options.ToCapabilities(), timeSpan);
        }

        public void SetUpChrome()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            //chromeOptions.AddAdditionalOption("se:recordVideo", true);
            //chromeOptions.AddAdditionalOption("se:screenResolution", "1920x1080");
            SetUpRemoteDriver(chromeOptions);
        }

        public void SetUpEdge()
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddArguments("--start-maximized");
            //edgeOptions.AddAdditionalOption("se:recordVideo", true);
            //edgeOptions.AddAdditionalOption("se:screenResolution", "1920x1080");
            SetUpRemoteDriver(edgeOptions);
        }

        public void SetUpFirefox()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            //firefoxOptions.AddAdditionalOption("se:recordVideo", true);
            //firefoxOptions.AddAdditionalOption("se:screenResolution", "1920x1080");
            SetUpRemoteDriver(firefoxOptions);
        }

        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        public void Dispose()
        {
            TearDown();
        }
    }
}