using System;

namespace Lab2_ExceptionManager
{
    class ExceptionManager
    {
        private IExceptionAnalyzer analyzer;
        private IWebServer webServer;
        private int criticalExceptionsCounter;
        private int nonCriticalExceptionsCounter;
        private int sendingErrorCounter;

        public ExceptionManager(IExceptionAnalyzer analyzer)
        {
            Analyzer = analyzer;
            WebServer = new WebServer();
            //WebServer = WebServerFactory.Create();
            ResetCounters();
        }

        public IExceptionAnalyzer Analyzer { get => analyzer; set => analyzer = value; }

        public IWebServer WebServer { get => webServer; set => webServer = value; }

        public void ResetCounters()
        {
            criticalExceptionsCounter = 0;
            nonCriticalExceptionsCounter = 0;
            sendingErrorCounter = 0;
        }

        public int GetCriticalExceptionsCount()
        {
            return criticalExceptionsCounter;
        }

        public int GetNonCriticalExceptionsCount()
        {
            return nonCriticalExceptionsCounter;
        }

        public int GetSendingErrorsCount()
        {
            return sendingErrorCounter;
        }

        public bool IsExceptionCritical(Exception exception)
        {
            if (Analyzer.IsExceptionCritical(exception))
            {
                criticalExceptionsCounter++;

                if (!WebServer.sendCriticalExceptionMessage(exception))
                {
                    sendingErrorCounter++;
                }

                return true;
            }
            else
            {
                nonCriticalExceptionsCounter++;

                return false;
            }
        }

        public void AnalyzeExceptions(params Exception[] exceptions)
        {
            foreach (var ex in exceptions)
            {
                IsExceptionCritical(ex);
            }
        }

        public override string ToString()
        {
            return $"[Critical Exceptions]: {GetCriticalExceptionsCount()} \n" +
                $"[Non-critical Exceptions]: {GetNonCriticalExceptionsCount()} \n" +
                $"[Sending Error]: { GetSendingErrorsCount()}";
        }
    }
}
