using OpenQA.Selenium;
using System;

namespace Lab3_Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = null;
  
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            start(driver, "http://todomvc.com/examples/angularjs/");

        }

        static void start(IWebDriver driver, string url)
        {
            
            driver.Navigate().GoToUrl(url);

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

        static void quit(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
