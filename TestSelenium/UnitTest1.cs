using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;






class JavaSDETClass 
{

    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;
    public JavaSDETClass(ref IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    public void Click()
    {
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//li[@class = 'et_pb_menu_page_id-217441 menu-item menu-item-type-custom menu-item-object-custom menu-item-217441'])[1]"))).Click();
    }
    public bool IsPageReady()
     {
        return driver.Url.Contains("https://academy.ultimateqa.com/java-sdet");
     }

   
}

class FillFields {

    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;
    public FillFields(ref IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    public void FillByXPath(string xpath, string key)
    {
        var tmp = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        tmp.SendKeys(key);
        tmp.SendKeys(Keys.Enter);
    }
    public void FillByClassName(string className,string key)
    {
    var tmp =    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(className)));
        tmp.SendKeys(key);
        tmp.SendKeys(Keys.Enter);
    }
    public void FillById(string id, string key)
    {
      var tmp = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
        tmp.SendKeys(key);
        tmp.SendKeys(Keys.Enter);
    }
    public void ClickById(string id)
    {
         driver.FindElement(By.Id(id)).Click();
    }
    public void ClickByXPath(string id)
    {
        driver.FindElement(By.XPath(id)).Click();
    }
    public bool IsPageReady()
    {
        return driver.Url.Contains("https://academy.ultimateqa.com/java-sdet");
    }

}


[TestFixture]
public class IntertopTests
{

    JavaSDETClass javaSDETClass;
    FillFields fill_obj;
    IWebDriver driver;
    [SetUp]
    public void SetUp()
    {


        new DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://ultimateqa.com/automation/");
        javaSDETClass = new JavaSDETClass(ref driver);
        fill_obj = new FillFields(ref driver);  
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    [Test]
    public void TestMethod() {

        javaSDETClass.Click();
        Assert.IsTrue(driver.Url == "https://academy.ultimateqa.com/java-sdet");

        fill_obj.FillById("form_submission_name", "My name");
       
        fill_obj.FillById("form_submission_email", "MyEmail@gmail.com");
        fill_obj.ClickById("form_submission_address_country");
        fill_obj.ClickByXPath("//option[@value = 'US']");
        fill_obj.ClickById("form_submission_custom_2");
        fill_obj.ClickByXPath("//option[@value = '18-24']");
        fill_obj.ClickById("form_submission_custom_3");
        fill_obj.ClickByXPath("//option[@value = 'High School']");
    

    }
}



