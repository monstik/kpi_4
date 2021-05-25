using System;

namespace Lab2_ExceptionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string configFilePath = @"C:\KPI\lab_2\critical_exceptions.config";
            IExceptionAnalyzer exceptionAnalyzer = new ExceptionAnalyzer(configFilePath);
            IExceptionAnalyzer fakeExceptionAnalyzer = new FakeExceptionAnalyzer(true);
            IWebServer fakeWebServer = new FakeWebServer(false);

            //WebServerFactory.SetWebServer(fakeWebServer);
            ExceptionManager exceptionManager = new ExceptionManager(fakeExceptionAnalyzer);
            exceptionManager.WebServer = fakeWebServer;

            exceptionManager.IsExceptionCritical(new IndexOutOfRangeException());

            exceptionManager.AnalyzeExceptions(
                new NullReferenceException(),
                new InvalidCastException(),
                new ArgumentOutOfRangeException()
            );

            
        }
    }
}
