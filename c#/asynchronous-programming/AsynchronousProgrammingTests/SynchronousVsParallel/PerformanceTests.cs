using System.Collections.Generic;
using System.Threading.Tasks;
using AsynchronousProgramming.SynchronousVsParallel;
using FluentAssertions;
using NUnit.Framework;

namespace AsynchronousProgrammingTests.SynchronousVsParallel
{
    [TestFixture]
    public class PerformanceTests
    {
        [Test]
        public async Task GivenTasksExecutedBothSynchronouslyAndInParallel_TotalExecutionTimeForParallelShouldBeQuicker()
        {
            // Arrange
            var sut = new Performance();
            // Act
            var synchronousExecutionTime = await sut.SynchronousExecution();
            var parallelExecutionTime = await sut.ParallelExecution();
            // Assert
            parallelExecutionTime.Should().BeLessThan(synchronousExecutionTime);
        }

        [Test]
        public async Task GivenTasksRunSynchronously_ShouldCompleteInCalledOrderRegardlessOfTimeToComplete()
        {
            // Arrange
            var expected = new List<string>
            {
                "I am the long running task",
                "I am the medium running task",
                "I am the short running task"
            };

            var sut = new Performance();
            // Act
            await sut.SynchronousExecution();
            var result = sut.SynchronousExecutionOrderResults;
            // Assert
            result.Should().BeEquivalentTo(expected);
        }       
        
        [Test]
        public async Task GivenTasksRunInParallel_ShouldCompleteInOrderOfShortestCompletionTime()
        {
            // Arrange
            var expected = new List<string>
            {
                "I am the short running task",
                "I am the medium running task",
                "I am the long running task"
            };

            var sut = new Performance();
            // Act
            await sut.ParallelExecution();
            var result = sut.ParallelExecutionOrderResults;
            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}