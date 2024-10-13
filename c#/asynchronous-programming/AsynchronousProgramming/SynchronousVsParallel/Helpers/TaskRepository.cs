using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchronousProgramming.SynchronousVsParallel.Helpers
{
    public class TaskRepository
    {
        private readonly List<string> _results = new();

        public List<string> FlushTaskCompletionResults()
        {
            var completionResults = _results.ToList();
            _results.Clear();
            return completionResults;
        }

        public async Task LongRunningMethodAsync()
        {
            await Task.Delay(500);
            _results.Add("I am the long running task");
        }

        public async Task MediumRunningMethodAsync()
        {
            await Task.Delay(300);
            _results.Add("I am the medium running task");
        }

        public async Task ShortRunningMethodAsync()
        {
            await Task.Delay(100);
            _results.Add("I am the short running task");
        }
    }
}