using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumGrid.Base
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver Driver { get; set; }
        private readonly Uri _seleniumGridUri = new("http://localhost:4444/");
        private readonly TimeSpan _timeoutTimeSpan = new(0, 3, 0);

        protected void SetUpRemoteDriver(DriverOptions driverOptions)
        {
            SetAdditionalDriverOptions(driverOptions);
            SetDriverConnection(driverOptions);
        }

        private void SetAdditionalDriverOptions(DriverOptions driverOptions)
        {
            driverOptions.AddAdditionalOption("se:recordVideo", true);
            driverOptions.AddAdditionalOption("se:screenResolution", "1920x1080");
        }

        private void SetDriverConnection(DriverOptions driverOptions)
        {
            Driver = new RemoteWebDriver(
                _seleniumGridUri, driverOptions.ToCapabilities(), _timeoutTimeSpan);
            Driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            TearDown();
        }

        private void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

    }
}