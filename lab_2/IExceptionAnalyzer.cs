using System;

namespace Lab2_ExceptionManager
{
    public interface IExceptionAnalyzer
    {
        bool IsExceptionCritical(Exception exception);
    }
}
