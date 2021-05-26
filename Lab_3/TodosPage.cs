using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lab3_Selenium
{
    class TodosPage
    {
        By InputFieldLocator = By.CssSelector(".new-todo");
        By ShowActiveButtonLocator = By.LinkText("Active");
        By ShowCompletedButtonLocator = By.LinkText("Completed");
        By ClearCompletedButtonLocator = By.CssSelector(".clear-completed");

        private IWebDriver webDriver;
        private WebDriverWait wait;

        public TodosPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            if (!"AngularJS • TodoMVC".Equals(webDriver.Title))
            {
                throw new Exception("This is not the todos page");
            }
        }

        public TodosPage AddTodo(string todoText)
        {
            wait.Until(d => d.FindElement(InputFieldLocator)).SendKeys(todoText + OpenQA.Selenium.Keys.Enter);

            return this;
        }

        public TodosPage DeleteTodo(int index)
        {
            IWebElement el = wait.Until(d => d.FindElement(By.CssSelector(".ng-scope:nth-child(" + index + ") > .view > .ng-binding")));
            Actions action = new Actions(webDriver);

            action.MoveToElement(el).Build().Perform();
            wait.Until(d => d.FindElement(By.CssSelector(".ng-scope:nth-child(" + index + ") > .view > .destroy"))).Click();

            return this;
        }

        public TodosPage CheckTodo(int index)
        {
            wait.Until(d => d.FindElement(By.CssSelector(".ng-scope:nth-child(" + index + ") > .view > .toggle"))).Click();

            return this;
        }

        public TodosPage ShowActive()
        {
            wait.Until(d => d.FindElement(ShowActiveButtonLocator)).Click();

            return this;
        }

        public TodosPage ShowCompleted()
        {
            wait.Until(d => d.FindElement(ShowCompletedButtonLocator)).Click();

            return this;
        }

        public TodosPage ClearCompleted()
        {
            wait.Until(d => d.FindElement(ClearCompletedButtonLocator)).Click();

            return this;
        }
    }
}
