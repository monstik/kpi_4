using System;

namespace Lab2_ExceptionManager
{
    class FakeWebServer : IWebServer
    {
        private bool isSuccessful;

        public FakeWebServer(bool IsSuccessful)
        {
            this.IsSuccessful = IsSuccessful;
        }

        public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }

        public bool sendCriticalExceptionMessage(Exception exception)
        {
            return IsSuccessful;
        }
    }
}
