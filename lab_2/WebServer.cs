using System;

namespace Lab2_ExceptionManager
{
    class WebServer : IWebServer
    {
        public WebServer()
        {
           
        }

        public bool sendCriticalExceptionMessage(Exception exception)
        {
            string message = exception.ToString();

            throw new NotImplementedException();
        }
    }
}
