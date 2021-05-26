using NSubstitute;
using NUnit.Framework;
using System;

namespace Lab2_ExceptionManager
{
    [TestFixture]
    class ExceptionManagerTests
    {
        private static Exception testException;

        [SetUp]
        public void Setup()
        {
            testException = new IndexOutOfRangeException();
        }


        [Test]
        public void IsExceptionCritical_CriticalException_ReturnsTrue()
        {
            // Arrange
            bool areAllExceptionsCritical = true;
            IExceptionAnalyzer fakeExceptionAnalyzer = new FakeExceptionAnalyzer(areAllExceptionsCritical);
            bool isSendingSuccessful = true;
            IWebServer webServer = new FakeWebServer(isSendingSuccessful);

            ExceptionManager exceptionManager = new ExceptionManager(fakeExceptionAnalyzer);
            exceptionManager.WebServer = webServer;

            // Act
            bool result = exceptionManager.IsExceptionCritical(testException);
            result &= exceptionManager.GetCriticalExceptionsCount() == 1;

            // Assert
            Assert.True(result);
        }


        [Test]
        public void IsExceptionCritical_NonCriticalException_ReturnsFalse()
        {
            // Arrange
            bool areAllExceptionsCritical = false;
            IExceptionAnalyzer fakeExceptionAnalyzer = new FakeExceptionAnalyzer(areAllExceptionsCritical);
            bool isSendingSuccessful = true;
            IWebServer webServer = new FakeWebServer(isSendingSuccessful);

            ExceptionManager exceptionManager = new ExceptionManager(fakeExceptionAnalyzer);
            exceptionManager.WebServer = webServer;

            // Act
            bool result = exceptionManager.IsExceptionCritical(testException);
            result &= exceptionManager.GetCriticalExceptionsCount() == 0;

            // Assert
            Assert.False(result);
        }


        [Test]
        public void SendCriticalExceptionMessage_CriticalException_CallWebServer()
        {
            // Arrange
            bool areAllExceptionsCritical = true;
            IExceptionAnalyzer fakeExceptionAnalyzer = new FakeExceptionAnalyzer(areAllExceptionsCritical);
            IWebServer webServer = Substitute.For<IWebServer>(); ;

            ExceptionManager exceptionManager = new ExceptionManager(fakeExceptionAnalyzer);
            exceptionManager.WebServer = webServer;

            // Act
            exceptionManager.IsExceptionCritical(testException);

            // Assert
            webServer.Received().sendCriticalExceptionMessage(testException);
        }


        [Test]
        public void SendCriticalExceptionMessage_NonCriticalException_CallWebServer()
        {
            // Arrange
            bool areAllExceptionsCritical = false;
            IExceptionAnalyzer fakeExceptionAnalyzer = new FakeExceptionAnalyzer(areAllExceptionsCritical);
            IWebServer webServer = Substitute.For<IWebServer>(); ;

            ExceptionManager exceptionManager = new ExceptionManager(fakeExceptionAnalyzer);
            exceptionManager.WebServer = webServer;

            // Act
            exceptionManager.IsExceptionCritical(testException);

            // Assert
            webServer.DidNotReceive().sendCriticalExceptionMessage(testException);
        }


        [Test]
        public void SendingErrorCounter_SendingFailed_ReturnsTrue()
        {
            // Arrange
            bool areAllExceptionsCritical = true;
            IExceptionAnalyzer fakeExceptionAnalyzer = new FakeExceptionAnalyzer(areAllExceptionsCritical);
            bool isSendingSuccessful = false;
            IWebServer webServer = new FakeWebServer(isSendingSuccessful);

            ExceptionManager exceptionManager = new ExceptionManager(fakeExceptionAnalyzer);
            exceptionManager.WebServer = webServer;

            int expected = 1;

            // Act
            exceptionManager.IsExceptionCritical(testException);
            int actual = exceptionManager.GetSendingErrorsCount();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void SendingErrorCounter_SuccessfulSending_ReturnsTrue()
        {
            // Arrange
            bool areAllExceptionsCritical = true;
            IExceptionAnalyzer fakeExceptionAnalyzer = new FakeExceptionAnalyzer(areAllExceptionsCritical);
            bool isSendingSuccessful = true;
            IWebServer webServer = new FakeWebServer(isSendingSuccessful);

            ExceptionManager exceptionManager = new ExceptionManager(fakeExceptionAnalyzer);
            exceptionManager.WebServer = webServer;

            int expected = 0;

            // Act
            exceptionManager.IsExceptionCritical(testException);
            int actual = exceptionManager.GetSendingErrorsCount();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

