using OpenQA.Selenium;
using Xunit;

namespace SeleniumGrid
{
    public class TestEdge : TestBase
    {
        public TestEdge()
        {
            SetUpEdge();
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