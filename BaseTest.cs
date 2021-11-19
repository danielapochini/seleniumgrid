using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SeleniumGrid
{
    public class BaseTest : IDisposable
    {
        public IWebDriver Driver { get; set; } 
        public string _hubGridUrl = "http://localhost:4444/"; 
        public TimeSpan _timeSpan = new TimeSpan(0, 3, 0);   

        public void SetUpBrowser(DriverOptions options)
        {
            SetBrowserOptions(options); 
            SetRemoteDriver(options);
        }

        public void SetBrowserOptions(DriverOptions options)
        {
            options.AddAdditionalOption("se:recordVideo", true);
            options.AddAdditionalOption("se:screenResolution", "1920x1080");
        }
 
        public void SetRemoteDriver(DriverOptions options)
        { 
            Driver = new RemoteWebDriver(
                new Uri(_hubGridUrl), options.ToCapabilities(), _timeSpan);
            Driver.Manage().Window.Maximize();
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