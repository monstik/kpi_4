namespace Lab2_ExceptionManager
{
    static class WebServerFactory
    {
        private static IWebServer webServer = null;

        public static IWebServer Create()
        {
            if(webServer != null)
            {
                return webServer;
            }

            return new WebServer();
        }

        public static void SetWebServer(IWebServer newWebServer)
        {
            webServer = newWebServer;
        }
    }
}
