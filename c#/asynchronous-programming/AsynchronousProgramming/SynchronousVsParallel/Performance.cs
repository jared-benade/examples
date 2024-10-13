using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AsynchronousProgramming.SynchronousVsParallel.Helpers;

namespace AsynchronousProgramming.SynchronousVsParallel
{
    public class Performance
    {
        private readonly TaskRepository _taskRepository;

        public Performance()
        {
            _taskRepository = new TaskRepository();
        }

        public List<string> SynchronousExecutionOrderResults { get; private set; }

        public List<string> ParallelExecutionOrderResults { get; private set; }

        public async Task<long> SynchronousExecution()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await _taskRepository.LongRunningMethodAsync();
            await _taskRepository.MediumRunningMethodAsync();
            await _taskRepository.ShortRunningMethodAsync();
            stopWatch.Stop();

            SynchronousExecutionOrderResults = _taskRepository.FlushTaskCompletionResults();

            return stopWatch.ElapsedMilliseconds;
        }

        public async Task<long> ParallelExecution()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await Task.WhenAll(_taskRepository.LongRunningMethodAsync(), _taskRepository.MediumRunningMethodAsync(),
                _taskRepository.ShortRunningMethodAsync());
            stopWatch.Stop();

            ParallelExecutionOrderResults = _taskRepository.FlushTaskCompletionResults();

            return stopWatch.ElapsedMilliseconds;
        }
    }
}