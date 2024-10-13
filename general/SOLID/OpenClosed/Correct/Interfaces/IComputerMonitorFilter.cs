using System.Collections.Generic;
using OpenClosed.Common.Models;

namespace OpenClosed.Correct.Interfaces
{
    public interface IComputerMonitorFilter
    {
        IEnumerable<ComputerMonitor> Filter(IEnumerable<ComputerMonitor> monitors,
            IEnumerable<ISpecification> specification);
    }
}