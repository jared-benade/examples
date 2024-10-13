using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AsynchronousProgramming.CancellationTokens;
using AsynchronousProgramming.CancellationTokens.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace AsynchronousProgrammingTests.CancellationTokens
{
    [TestFixture]
    public class BasicUsageTests
    {
        private readonly List<Account> _initialAccountsState;

        public BasicUsageTests()
        {
            _initialAccountsState = new List<Account>
            {
                new(1, "Jimmy Jones", true),
                new(2, "Jane Doe", false)
            };
        }

        [Test]
        public async Task GivenTaskCancelledBeforeActivateAccountsIsCalled_AccountsShouldNotBeUpdated()
        {
            // Arrange
            const int timeBeforeActivateAccountsIsCalled = 50;
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(timeBeforeActivateAccountsIsCalled);

            var sut = CreateSut();
            // Act
            var result = await sut.ActivateAllAccountsAsync(cancellationTokenSource.Token);
            // Assert
            result.Should().Be("Nothing really happened :|");

            var accounts = await sut.GetAllAccountsAsync();
            accounts.Should().BeEquivalentTo(_initialAccountsState);
        }      
        
        [Test]
        public async Task GivenTaskCancelledAfterActivateAccountsIsCalled_ButBeforeTaskCompletes_RollbackShouldBeCalled_AndAccountsShouldNotBeUpdated()
        {
            // Arrange
            const int timeAfterActivateAccountsIsCalled = 150;
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(timeAfterActivateAccountsIsCalled);

            var sut = CreateSut();
            // Act
            var result = await sut.ActivateAllAccountsAsync(cancellationTokenSource.Token);
            // Assert
            result.Should().Be("Had to rollback :(");

            var accounts = await sut.GetAllAccountsAsync();
            accounts.Should().BeEquivalentTo(_initialAccountsState);
        }    
        
        [Test]
        public async Task GivenTaskCancelledAfterTaskIsComplete_ShouldUpdateAccounts_AndNotProcessCancellationRequest()
        {
            // Arrange
            const int timeAfterTaskHasCompleted = 500;
            var expectedAccounts = new List<Account>
            {
                new(1, "Jimmy Jones", true),
                new(2, "Jane Doe", true)
            };
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(timeAfterTaskHasCompleted);

            var sut = CreateSut();
            // Act
            var result = await sut.ActivateAllAccountsAsync(cancellationTokenSource.Token);
            // Assert
            result.Should().Be("Changes were successfully applied :D");

            var accounts = await sut.GetAllAccountsAsync();
            accounts.Should().BeEquivalentTo(expectedAccounts);
        }

        private static BasicUsage CreateSut()
        {
            return new BasicUsage();
        }
    }
}