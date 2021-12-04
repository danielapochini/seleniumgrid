using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumGrid.Base;
using Xunit;

namespace SeleniumGrid.Tests
{
    public class TestChrome : BaseTest
    {
        public TestChrome()
        {
            SetUpRemoteDriver(new ChromeOptions());
        }

        [Fact]
        public void TestChromeNode()
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
