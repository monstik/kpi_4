using System;

namespace Lab_1_ExceptionManager
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Exception[] criticalExceptionsArray = new Exception[]
            {
                new IndexOutOfRangeException(),
                new DivideByZeroException(),
                new NullReferenceException(),
            };

            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsArray);

            exceptionManager.IsExceptionCritical(new IndexOutOfRangeException());

            exceptionManager.AnalyzeExceptions(
                new NullReferenceException(),
                new InvalidCastException(),
                new ArgumentOutOfRangeException()
            );


        }
    }
}
