using OpenClosed.Common.Models;

namespace OpenClosed.Correct.Interfaces
{
    public interface ISpecification
    {
        bool IsSatisfied(ComputerMonitor monitor);
    }
}