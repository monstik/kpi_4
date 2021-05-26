using System;

namespace Lab2_ExceptionManager
{
    public interface IWebServer
    {
        bool sendCriticalExceptionMessage(Exception exception);
    }
}
