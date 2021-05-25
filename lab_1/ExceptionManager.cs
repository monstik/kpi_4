using System;

namespace Lab_1_ExceptionManager
{
    class ExceptionManager
    {
        private Exception[] criticalExceptionsArray;
        private int criticalExceptionsCounter;
        private int nonCriticalExceptionsCounter;


        public ExceptionManager(Exception[] criticalExceptionsArray)
        {
            SetCriticalExceptionsArray(criticalExceptionsArray);
            ResetCounters();
        }

        
        public void ResetCounters()
        {
            criticalExceptionsCounter = 0;
            nonCriticalExceptionsCounter = 0;
        }

        
        public int GetCriticalExceptionsCount()
        {
            return criticalExceptionsCounter;
        }

        
        public int GetNonCriticalExceptionsCount()
        {
            return nonCriticalExceptionsCounter;
        }

        
        public void SetCriticalExceptionsArray(Exception[] criticalExceptionsArray)
        {
            this.criticalExceptionsArray = new Exception[criticalExceptionsArray.Length];
            criticalExceptionsArray.CopyTo(this.criticalExceptionsArray, 0);
        }

        
        public Exception[] GetCriticalExceptionsArray()
        {
            Exception[] criticalExceptionsArray = new Exception[this.criticalExceptionsArray.Length];
            this.criticalExceptionsArray.CopyTo(criticalExceptionsArray, 0);

            return criticalExceptionsArray;
        }

        public bool IsExceptionCritical(Exception exception)
        {
            if (Contains(exception))
            {
                criticalExceptionsCounter++;

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

        
        private bool Contains(Exception exception)
        {
            foreach (Exception criticalException in criticalExceptionsArray)
            {
                if (exception.GetType() == criticalException.GetType())
                {
                    return true;
                }
            }

            return false;
        }

       
        public override string ToString()
        {
            string criticalExceptionsArrayStr = "";

            foreach (Exception criticalException in criticalExceptionsArray)
            {
                criticalExceptionsArrayStr += $"\n\t{criticalException.GetType()}";
            }

            return $"[Critical Exceptions Array]: {criticalExceptionsArrayStr} \n\n" +
                $"[Critical Exceptions]: {GetCriticalExceptionsCount()} \n" +
                $"[Non-critical Exceptions]: {GetNonCriticalExceptionsCount()}";
        }
    }
}
