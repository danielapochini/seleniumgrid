using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SeleniumGrid.Base;
using Xunit;

namespace SeleniumGrid.Tests
{
    public class TestEdge : BaseTest
    {
        public TestEdge()
        {
            SetUpRemoteDriver(new EdgeOptions());
        }

        [Fact]
        public void TestEdgeNode()
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