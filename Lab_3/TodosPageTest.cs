using NUnit.Framework;
using OpenQA.Selenium;

namespace Lab3_Selenium
{
    class TodosPageTest
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void test()
        {
            driver.Navigate().GoToUrl("http://todomvc.com/examples/angularjs/");

            TodosPage site = new TodosPage(driver);

            site.AddTodo("test1");
            site.AddTodo("test2");
            site.AddTodo("test3");
            site.AddTodo("test4");
            site.AddTodo("test5");

            site.DeleteTodo(3);

            site.CheckTodo(1);
            site.CheckTodo(2);

            site.ShowActive();
            site.ShowCompleted();
            site.ClearCompleted();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}
