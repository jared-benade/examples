using System.Collections.Generic;
using System.Linq;
using OpenClosed.Common.Models;
using OpenClosed.Correct.Interfaces;

namespace OpenClosed.Correct.Services
{
    public class ComputerMonitorFilter : IComputerMonitorFilter
    {
        public IEnumerable<ComputerMonitor> Filter(IEnumerable<ComputerMonitor> monitors,
            IEnumerable<ISpecification> specifications)
        {
            return specifications.Aggregate(monitors,
                (filteredMonitors, specification) => filteredMonitors.Where(specification.IsSatisfied));
        }
    }
}