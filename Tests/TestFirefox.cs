using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumGrid.Base;
using Xunit;

namespace SeleniumGrid.Tests
{
    public class TestFirefox : BaseTest
    {
        public TestFirefox()
        {
            SetUpRemoteDriver(new FirefoxOptions());
        }

        [Fact]
        public void TestFirefoxNode()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Driver.FindElement(By.Id("user-name")).SendKeys("Teste");
            Driver.FindElement(By.Id("login-button")).Submit();

            string mensagemEsperada = "Epic sadface: Password is required";
            string mensagemAtual = Driver.FindElement(By.XPath("//div[@class='error-message-container error']//h3")).Text;

            Assert.Equal(mensagemEsperada, mensagemAtual);
        }

    }
}