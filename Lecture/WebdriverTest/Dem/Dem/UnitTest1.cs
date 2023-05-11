namespace Dem;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Tests
{
    private WebDriver WebDriver { get; set; } = null;
    private string DriverPath { get; set; } = @"chromedriver.exe";
    private string BaseUrl { get; set; } = "https://www.blazingchat.com/";

    [SetUp]
    public void Setup()
    {
        WebDriver = GetChromeDriver();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }

    [Test]
    public void CheckUrlName()
    {
        WebDriver.Navigate().GoToUrl(BaseUrl);

        Assert.AreEqual("BlazingChat", WebDriver.Title);
    }

    [Test]
    public void LogIn()
    {
        WebDriver.Navigate().GoToUrl(BaseUrl);

        // Enter EmailAddress
        Thread.Sleep(5000);
        var input = WebDriver.FindElement(By.Id("input_emailaddress"));
        input.Clear();
        input.SendKeys("tiheco2092@jwsuns.com");

        // Enter Password
        Thread.Sleep(5000);
        input = WebDriver.FindElement(By.Id("input_password"));
        input.Clear();
        input.SendKeys("tiheco2092@jwsuns.com");

        // Click on Login button
        Thread.Sleep(5000);
        input = WebDriver.FindElement(By.Id("button_login"));
        input.Click();

        input = WebDriver.FindElement(By.Id("p_welcome_message"));
        Assert.AreEqual("Hello, tiheco2092@jwsuns.com", input.Text);
    }


    private WebDriver GetChromeDriver()
    {
        var options = new ChromeOptions();
        //options.AddArguments("--headless");

        return new ChromeDriver(DriverPath, options, TimeSpan.FromSeconds(300));
    }
}