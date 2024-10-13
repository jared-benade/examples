using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsynchronousProgramming.AsyncAwait;
using AsynchronousProgramming.AsyncAwait.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace AsynchronousProgrammingTests.AsyncAwait
{
    [TestFixture]
    public class BasicUsageTests
    {
        [Test]
        public async Task GivenAsyncMethod_ShouldBeAbleToAwaitAssertion()
        {
            // Arrange
            var sut = CreateSut();
            // Act
            // Assert
            // NUnit standard syntax
            Assert.DoesNotThrowAsync(async () => await sut.SaveNewCustomers());

            // Fluent assertions standard syntax
            await sut.Invoking(x => x.SaveNewCustomers()).Should().NotThrowAsync<Exception>();

            // Fluent assertions arrange - act - assert syntax
            Func<Task> act = async () => await sut.SaveNewCustomers();
            await act.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task GivenAsyncMethodThrowsException_ShouldCanUseTryCatchSyntax()
        {
            // Arrange
            const string expectedErrorMessage = "Could not find matching customer";

            var sut = CreateSut();
            // Act
            try
            {
                await sut.FindCustomer();
            }
            catch (Exception ex)
            {
                // Assert
                ex.Message.Should().Be(expectedErrorMessage);

                var logs = CustomLogger.GetLogs();
                logs.Count.Should().Be(1);
                logs.ElementAt(0).Should().Be(expectedErrorMessage);
            }
        }

        [Test]
        public async Task GivenAsyncMethodReturnsTaskOfT_ShouldBeAbleToAwaitMethodCallAndRetrieveTResult()
        {
            // Arrange
            var sut = CreateSut();
            // Act
            var customers = await sut.GetCustomers();
            // Assert
            customers.Should().BeOfType<List<Customer>>();
        }

        private static BasicUsage CreateSut()
        {
            return new();
        }
    }
}