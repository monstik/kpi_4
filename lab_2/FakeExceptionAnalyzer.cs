using System;

namespace Lab2_ExceptionManager
{
    class FakeExceptionAnalyzer : IExceptionAnalyzer
    {
        private bool isCritical;

        public FakeExceptionAnalyzer(bool IsCritical)
        {
            this.IsCritical = IsCritical;
        }

        public bool IsCritical { get => isCritical; set => isCritical = value; }

        public bool IsExceptionCritical(Exception exception)
        {
            return IsCritical;
        }
    }
}
