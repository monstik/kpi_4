using NUnit.Framework;
using System;

namespace Lab_1_ExceptionManager
{
    [TestFixture]
    class ExceptionManagerTests
    {
        private static Exception nonCriticalException;
        private static Exception criticalException;
        private static Exception[] criticalExceptionsArray;


        [SetUp]
        public void Setup()
        {
            nonCriticalException = new Exception();
            criticalException = new IndexOutOfRangeException();

            criticalExceptionsArray = new Exception[]
            {
                criticalException,
                new DivideByZeroException(),
                new NullReferenceException(),
            };
        }


        [Test]
        public void IsExceptionCritical_CriticalException_ReturnsTrue()
        {
            // Arrange
            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsArray);

            // Act
            bool result = exceptionManager.IsExceptionCritical(criticalException);
            result &= exceptionManager.GetCriticalExceptionsCount() == 1;

            // Assert
            Assert.True(result);
        }


        [Test]
        public void IsExceptionCritical_NonCriticalException_ReturnsFalse()
        {
            // Arrange
            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsArray);

            // Act
            bool result = exceptionManager.IsExceptionCritical(nonCriticalException);
            result &= exceptionManager.GetCriticalExceptionsCount() == 0;

            // Assert
            Assert.False(result);
        }


        [Test]
        public void AnalyzeExceptions_CriticalException_ReturnsTrue()
        {
            // Arrange
            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsArray);

            // Act
            exceptionManager.AnalyzeExceptions(criticalException);
            bool result = exceptionManager.GetCriticalExceptionsCount() == 1 &&
                exceptionManager.GetNonCriticalExceptionsCount() == 0;

            // Assert
            Assert.True(result);
        }


        [Test]
        public void AnalyzeExceptions_NonCriticalException_ReturnsTrue()
        {
            // Arrange
            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsArray);

            // Act
            exceptionManager.AnalyzeExceptions(nonCriticalException);
            bool result = exceptionManager.GetCriticalExceptionsCount() == 0 &&
                exceptionManager.GetNonCriticalExceptionsCount() == 1;

            // Assert
            Assert.True(result);
        }


        [Test]
        public void AnalyzeExceptions_CriticalExceptionAndNonCriticalException_ReturnsTrue()
        {
            // Arrange
            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsArray);

            // Act
            exceptionManager.AnalyzeExceptions(criticalException, nonCriticalException);
            bool result = exceptionManager.GetCriticalExceptionsCount() == 1 &&
                exceptionManager.GetNonCriticalExceptionsCount() == 1;

            // Assert
            Assert.True(result);
        }
    }
}
