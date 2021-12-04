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
        public Uri _seleniumGridUri = new Uri("http://localhost:4444/"); 
        public TimeSpan _timeSpan = new TimeSpan(0, 3, 0);   

        public void SetUpRemoteDriver(DriverOptions driverOptions)
        {
            SetAdditionalDriverOptions(driverOptions); 
            SetDriverConnection(driverOptions);
        }

        public void SetAdditionalDriverOptions(DriverOptions driverOptions)
        {
            driverOptions.AddAdditionalOption("se:recordVideo", true);
            driverOptions.AddAdditionalOption("se:screenResolution", "1920x1080");
        }
 
        public void SetDriverConnection(DriverOptions driverOptions)
        { 
            Driver = new RemoteWebDriver(
                _seleniumGridUri, driverOptions.ToCapabilities(), _timeSpan);
            Driver.Manage().Window.Maximize();
        }
 
        public void Dispose()
        {
            TearDown();
        }

        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

    }
}