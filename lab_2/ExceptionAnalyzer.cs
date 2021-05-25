using System;
using System.IO;

namespace Lab2_ExceptionManager
{
    class ExceptionAnalyzer : IExceptionAnalyzer
    {
        public string configFilePath;

        public ExceptionAnalyzer(string configFilePath)
        {
            this.configFilePath = configFilePath;
        }

        public bool IsExceptionCritical(Exception exception)
        {
            if (Contains(exception))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Contains(Exception exception)
        {
            using (StreamReader sr = new StreamReader(configFilePath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (exception.GetType().ToString().Equals(line))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
